using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
	public class IncidentService
	{
		private readonly AppDBContext _dbContext;

		public IncidentService(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<IncidentAudit>> GetAllIncidents()
		{
			return await _dbContext.IncidentAudit.ToListAsync();
		}
	}
}
