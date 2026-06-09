using Entities.Models;
using HealthMonitoringData.Data;

namespace Application.Services
{
	public class SiteService
	{
		private readonly AppDBContext _dbContext;

		public SiteService(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<Site> GetAllSites()
		{
			return _dbContext.Site.ToList();
		}
	}
}
