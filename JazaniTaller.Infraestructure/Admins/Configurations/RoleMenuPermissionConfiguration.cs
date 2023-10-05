using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Infraestructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JazaniTaller.Infraestructure.Admins.Configurations
{
    public class RoleMenuPermissionConfiguration: IEntityTypeConfiguration<RoleMenuPermission>
    {
        public void Configure(EntityTypeBuilder<RoleMenuPermission> builder)
        {
            builder.ToTable("rolemenupermission", "adm");            
            builder.Property(x => x.RoleId).HasColumnName("roleid");
            builder.Property(x => x.MenuId).HasColumnName("menuid");
            builder.Property(x => x.PermissionId).HasColumnName("permissionid");
            //id compuesto
            builder.HasKey(x => new { x.MenuId, x.RoleId, x.PermissionId });
            builder.Property(t => t.RegistrationDate)
                 .HasColumnName("registrationdate")
                 .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");

            // Restricción FOREIGN KEY
            builder.HasOne(x => x.Menu)
                   .WithMany(many => many.RoleMenuPermissions)
                   .HasForeignKey(x => x.MenuId);

            builder.HasOne(x => x.Role)
                   .WithMany(many => many.RoleMenuPermissions)
                   .HasForeignKey(x => x.RoleId);
        }
    }
}
