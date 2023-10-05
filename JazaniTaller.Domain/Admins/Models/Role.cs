namespace JazaniTaller.Domain.Admins.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual ICollection<RoleMenuPermission> RoleMenuPermissions { get; set; }
    }
}
