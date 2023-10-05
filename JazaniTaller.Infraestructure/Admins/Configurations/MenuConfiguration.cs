using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Infraestructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JazaniTaller.Infraestructure.Admins.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("menu", "adm");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MenuId).HasColumnName("menuid");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Slug).HasColumnName("slug");
            builder.Property(x => x.Order).HasColumnName("order");
            builder.Property(x => x.Level).HasColumnName("level");
            builder.Property(x => x.Url).HasColumnName("url");
            builder.Property(x => x.Image).HasColumnName("image");
            builder.Property(x => x.Visible).HasColumnName("visible");
            builder.Property(t => t.RegistrationDate)
                 .HasColumnName("registrationdate")
                 .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");

            builder.HasOne(x => x.MenuPadre)
           .WithMany(many => many.Menus)
           .HasForeignKey(x => x.MenuId);
        }
    }
}
