using System.ComponentModel.DataAnnotations;

namespace AuthApp.Service.Models
{
    public class AccountCreateModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
        public List<Guid>? PermisisonGroupIds { get; set; }
    }
}
