using Data.Models;

namespace Application.Services
{
	public class MonitoringService
	{
		private readonly SiteService _siteService;
		private readonly HttpClient _httpClient;
		private readonly IncidentService _incidentService;

		public MonitoringService(SiteService siteService, HttpClient httpClient, IncidentService incidentService)
		{
			_siteService = siteService;
			_httpClient = httpClient;
			_incidentService = incidentService;
		}

		public async Task MonitorSites()
		{
			var sites = await _siteService.GetAllSites();

			foreach (var site in sites.Where(x => x.IsActive))
			{
				var startedAt = DateTime.UtcNow;

				try
				{
					var normalizedUrl = NormalizeUrl(site.Url);
					using var response = await _httpClient.GetAsync(normalizedUrl);

					var incidentAudit = new IncidentAudit
					{
						SiteId = site.Id,
						Status = response.IsSuccessStatusCode ? "Ok" : "Down",
						StatusCode = (int)response.StatusCode,
						Message = response.IsSuccessStatusCode? "Site responded successfully": $"Site returned {(int)response.StatusCode}",
						CreatedAt = startedAt,
						Site = site
					};

					await _incidentService.AddIncident(incidentAudit);

					site.LastCheckedAt = startedAt;

					await _siteService.UpdateSite(site);
				}
				catch (Exception ex)
				{
					var incidentAudit = new IncidentAudit
					{
						SiteId = site.Id,
						Status = "ERROR",
						StatusCode = null,
						Message = ex.Message,
						CreatedAt = startedAt
					};

					await _incidentService.AddIncident(incidentAudit);

					site.LastCheckedAt = startedAt;
					await _siteService.UpdateSite(site);
				}
			}
		}

		private static string NormalizeUrl(string url)
		{
			if (!url.StartsWith("http://") && !url.StartsWith("https://"))
			{
				url = $"https://{url}";
			}

			return url;
		}
	}
}
