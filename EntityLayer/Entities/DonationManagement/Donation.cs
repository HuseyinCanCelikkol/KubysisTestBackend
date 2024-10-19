using Common.Enums.DonationManagement;
using EntityLayer.Entities.BaseEntityManagement;
using EntityLayer.Entities.CompanyManagement;

namespace EntityLayer.Entities.DonationManagement
{
    public class Donation : BaseEntity, IUserBased
    {
        public required string NameAndSurname { get; set; }
        public DonationType? DonationType { get; set; }
        public DonationClass DonationClass { get; set; }
        public int Amount { get; set; }
        public required string PhoneNumber { get; set; }
        public DonationStatus DonationStatus { get; set; }
        public string? Description { get; set; }
        public int CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        public required string CreateUserId { get; set; }
        public string? UpdateUserId { get; set; }
    }
}
