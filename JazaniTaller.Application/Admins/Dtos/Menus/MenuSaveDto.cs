namespace JazaniTaller.Application.Admins.Dtos.Menus
{
    public class MenuSaveDto
    {
        public int? MenuId { get; set; }
        public string Name { get; set; }
        public string? Slug { get; set; }
        public int Order { get; set; }
        public int Level { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public bool Visible { get; set; }
    }
}
