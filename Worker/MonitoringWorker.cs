using Application.Services;

namespace Worker;

public class MonitoringWorker : BackgroundService
{
	private readonly IServiceProvider _serviceProvider;

	public MonitoringWorker(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			using var scope = _serviceProvider.CreateScope();
			var monitoringService = scope.ServiceProvider.GetRequiredService<MonitoringService>();
			await monitoringService.MonitorSitesAsync();

			var interval = int.Parse(Environment.GetEnvironmentVariable("JOB_INTERVAL_SEC") ?? "60");
			await Task.Delay(TimeSpan.FromSeconds(interval), stoppingToken);
		}
	}
}