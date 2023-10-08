using JazaniTaller.Domain.MC.Models;
using JazaniTaller.Infraestructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JazaniTaller.Infraestructure.MC.Configurations
{
    public class InvestmentConceptConfiguration : IEntityTypeConfiguration<InvestmentConcept>
    {
        public void Configure(EntityTypeBuilder<InvestmentConcept> builder)
        {
            builder.ToTable("investmentconcept", "mc");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}