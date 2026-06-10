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
		using var scope = _serviceProvider.CreateScope();

		var monitoringService = scope.ServiceProvider
			.GetRequiredService<MonitoringService>();

		await monitoringService.MonitorSites();
	}
}