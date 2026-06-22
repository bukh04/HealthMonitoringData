using Data;
using Data.Models;
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

		public async Task<List<Site>> GetAllSitesAsync()
		{
			return await _dbContext.Site.ToListAsync();
		}

		public async Task<bool> DeleteSiteByIdAsync(int id)
		{
			var site = await _dbContext.Site.FindAsync(id);
			if (site == null) return false;

			_dbContext.Site.Remove(site);
			await _dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<Site> AddSiteAsync(Site site)
		{
			_dbContext.Site.Add(site);
			await _dbContext.SaveChangesAsync();
			return site;
		}

		public async Task UpdateSiteAsync(Site site)
		{
			_dbContext.Site.Update(site);
			await _dbContext.SaveChangesAsync();
		}
	}
}
