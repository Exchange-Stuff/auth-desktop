namespace AuthApp.Service.Models
{
    /// <summary>
    /// PermissionGroup <=> Permission group
    /// </summary>
    public class PermissionResourceAddModel
    {
        public Guid ResourceId { get; set; }
        public string ResourceName { get; set; }
        public int PermissionValue { get; set; }
        public bool FullControl { get; set; } 
    }
}
