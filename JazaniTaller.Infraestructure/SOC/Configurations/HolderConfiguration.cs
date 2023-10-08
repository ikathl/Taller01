using JazaniTaller.Domain.SOC.Models;
using JazaniTaller.Infraestructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JazaniTaller.Infraestructure.SOC.Configurations
{
    public class HolderConfiguration : IEntityTypeConfiguration<Holder>
    {
        public void Configure(EntityTypeBuilder<Holder> builder)
        {
            builder.ToTable("holder", "soc");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Lastname).HasColumnName("lastname");
            builder.Property(x => x.MaidenName).HasColumnName("maidenname");
            builder.Property(x => x.DocumentNumber).HasColumnName("documentnumber");
            builder.Property(x => x.LandLine).HasColumnName("landline");
            builder.Property(x => x.Mobile).HasColumnName("mobile");
            builder.Property(x => x.Corporatemail).HasColumnName("corporatemail");
            builder.Property(x => x.PersonalMail).HasColumnName("personalmail");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
