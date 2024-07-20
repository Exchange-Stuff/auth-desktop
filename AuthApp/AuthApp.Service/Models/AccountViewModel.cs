using AuthApp.Service.DTOs;

namespace AuthApp.Service.Models
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Thumbnail { get; set; }
        public List<PermissionGroupDTO> PermissionGroups { get; set; }
    }
}
