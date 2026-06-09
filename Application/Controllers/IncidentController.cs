using Application.Services;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class IncidentController : ControllerBase
	{
		private readonly IncidentService _incidentService;

		public IncidentController(IncidentService incidentService)
		{
			_incidentService = incidentService;
		}

		[HttpGet]
		public  Task<List<IncidentAudit>> GetAllIncidents()
		{
			return _incidentService.GetAllIncidents();
		}

	}
}
