namespace Data.Models
{
	public class Site
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Url { get; set; } = null!;

		public bool IsActive { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? LastCheckedAt { get; set; }
	}
}
