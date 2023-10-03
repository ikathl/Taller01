using JazaniTaller.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JazaniTaller.Infraestructure.Admins.Configurations
{
    public class RoleMenuPermissionConfiguration: IEntityTypeConfiguration<RoleMenuPermission>
    {
        public void Configure(EntityTypeBuilder<RoleMenuPermission> builder)
        {
            builder.ToTable("rolemenupermission", "adm");
            builder.HasKey(x => x.RoleId);
            builder.Property(x => x.MenuId).HasColumnName("menuid");
            builder.Property(x => x.PermissionId).HasColumnName("permissionid");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate");
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
