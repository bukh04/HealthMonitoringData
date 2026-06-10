using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Application
{
	public class AppDBContext: DbContext
	{
		public AppDBContext(DbContextOptions<AppDBContext> options): base(options){}

		public DbSet<Site> Site { get; set; }
		public DbSet<IncidentAudit> IncidentAudit { get; set; }
	}
}
