﻿namespace JazaniTaller.Domain.Admins.Models
{
    public class RoleMenuPermission
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public int PermissionId { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
