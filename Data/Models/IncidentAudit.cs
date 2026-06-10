namespace Data.Models
{
	public class IncidentAudit
	{
		public int Id { get; set; }

		public int SiteId { get; set; }

		public string? Message { get; set; }

		public string? Status { get; set; }

		public int? StatusCode { get; set; }

		public DateTime CreatedAt { get; set; }

		public Site Site { get; set; } = new Site();
	}
}
