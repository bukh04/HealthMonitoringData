using Entities.Models;
using HealthMonitoringData.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
	public class SiteService
	{
		private readonly AppDBContext _dbContext;

		public SiteService(AppDBContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<Site>> GetAllSites()
		{
			return await _dbContext.Site.ToListAsync();
		}

		public async Task DeleteSiteById(int id)
		{
			var site = await _dbContext.Site.FindAsync(id);
			if (site != null)
			{
				_dbContext.Site.Remove(site);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<Site> AddSite(Site site)
		{
			_dbContext.Site.Add(site);
			await _dbContext.SaveChangesAsync();
			return site;
		}
	}
}
