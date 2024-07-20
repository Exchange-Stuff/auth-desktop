namespace AuthApp.Service.Models
{
    public class UpdatePermissionGroupModel
    {
        /// <summary>
        /// Now Lookeach ROLE is PERMISSION GROUP, update later
        /// </summary>
        public Guid PermissionGroupId { get; set; }
        public List<ResourceRecord> ResourceValueRecords { get; set; }
    }
    public sealed record ResourceRecord(Guid ResourceId, int PermissionValue);
}
