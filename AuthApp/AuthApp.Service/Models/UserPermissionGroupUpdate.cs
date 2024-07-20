namespace AuthApp.Service.Models
{
    public class UserPermissionGroupUpdate
    {
        public Guid AccountId { get; set; }
        public List<Guid> PermissionGroupIds { get; set; }
    }
}
