namespace EntityLayer.Entities.BaseEntityManagement
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.Now;
		public DateTime? UpdateDate { get; set; }
	}
}
