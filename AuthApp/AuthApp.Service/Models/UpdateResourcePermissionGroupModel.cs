namespace AuthApp.Service.Models
{
    public class UpdateResourcePermissionGroupModel
    {
        public Guid ResourceId { get; set; }
        public string ResourceName { get; set; }
        public int PermissionValue { get; set; }
        public bool Selected { get; set; }
        public bool FullControl { get; set; }
    }
}
