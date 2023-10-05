namespace JazaniTaller.Domain.Admins.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public int? MenuId { get; set; }
        public string Name { get; set; }
        public string? Slug { get; set; }
        public int Order { get; set; }
        public int Level { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public bool Visible { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual ICollection<RoleMenuPermission> RoleMenuPermissions { get; set; }

        public virtual Menu? MenuPadre { get; set; }
        public virtual ICollection<Menu?> Menus { get; set; }

    }
}
