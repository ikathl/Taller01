using JazaniTaller.Domain.Generals.Models;
using JazaniTaller.Infraestructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JazaniTaller.Infraestructure.Generals.Configurations
{
    public class MeasureUnitConfiguration : IEntityTypeConfiguration<MeasureUnit>
    {
        public void Configure(EntityTypeBuilder<MeasureUnit> builder)
        {
            builder.ToTable("measureunit", "ge");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MeasureUnitId).HasColumnName("measureunitid");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Symbol).HasColumnName("symbol");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
