namespace JazaniTaller.Domain.Admins.Models
{
    public class RoleMenuPermission
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public int PermissionId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Role Role { get; set; }
    }
}
