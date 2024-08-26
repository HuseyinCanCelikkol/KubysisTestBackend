using Common.Enums.DonationManagement;
using EntityLayer.Entities.BaseEntityManagement;

namespace EntityLayer.Entities.DonationManagement
{
	public class Donation : BaseEntity
    {
        public required string NameAndSurname { get; set; }
        public DonationType? DonationType { get; set; }
        public DonationClass DonationClass { get; set; }
        public int Amount { get; set; }
        public required string PhoneNumber { get; set; }
        public DonationStatus DonationStatus { get; set; }
        public string? Description { get; set; }
    }
}
