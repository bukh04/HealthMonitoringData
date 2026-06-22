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
		public async Task<List<Site>> GetAllSites()
		{
			return await _siteService.GetAllSitesAsync();
		}

		[HttpDelete("{id}")] 
		public async Task<IActionResult> DeleteSiteById(int id)
		{
			var result = await _siteService.DeleteSiteByIdAsync(id);
			if (!result) 
				return NotFound();

			return Ok();
		}

		[HttpPost]
		public async Task<Site> AddSite(Site site)
		{
			if (string.IsNullOrEmpty(site.Name) || string.IsNullOrEmpty(site.Url))
			{
				throw new ArgumentException("Site name and URL cannot be empty.");
			}

			return await _siteService.AddSiteAsync(site);
		}
	}
}
