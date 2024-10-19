namespace EntityLayer.Entities.BaseEntityManagement
{
    public interface IUserBased
    {
        public string CreateUserId { get; set; }
        public string? UpdateUserId { get; set; }
    }
}
