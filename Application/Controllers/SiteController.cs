using Application.Services;
using Entities.Models;
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
		public List<Site> GetAllSites()
		{
			return _siteService.GetAllSites();
		}
	}
}
