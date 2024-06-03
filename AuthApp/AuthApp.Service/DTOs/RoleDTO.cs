namespace AuthApp.Service.DTOs
{
    public class RoleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ActionValue { get; set; }
        public ICollection<ResourceDTO> Resources { get; set; }
    }
}
