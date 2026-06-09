using Application.Services;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class SiteController : ControllerBase
	{
		public readonly SiteService _siteService;

		public SiteController(SiteService siteService)
		{
			_siteService = siteService;
		}

		[HttpGet]
		public Task <List<Site>> GetAllSites()
		{
			return _siteService.GetAllSites();
		}

		[HttpDelete("{id}")] 
		public Task<IActionResult> DeleteSiteById(int id)
		{
			var result = _siteService.DeleteSiteById(id);

			if (result == null)
			{
				return Task.FromResult<IActionResult>(NotFound());
			}

			return Task.FromResult<IActionResult>(Ok(result));
		}

		[HttpPost]
		public Task<Site> AddSite(Site site)
		{
			if (string.IsNullOrEmpty(site.Name) || string.IsNullOrEmpty(site.Url))
			{
				throw new ArgumentException("Site name and URL cannot be empty.");
			}

			return _siteService.AddSite(site);
		}
	}
}
