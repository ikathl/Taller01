using JazaniTaller.Domain.MC.Models;
using JazaniTaller.Infraestructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JazaniTaller.Infraestructure.MC.Configurations
{
    public class MiningConcessionConfiguration : IEntityTypeConfiguration<MiningConcession>
    {
        public void Configure(EntityTypeBuilder<MiningConcession> builder)
        {
            builder.ToTable("miningconcession", "mc");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
            .HasColumnName("code");

            builder.Property(x => x.Name)
                .HasColumnName("name");

            builder.Property(x => x.Observation)
                .HasColumnName("observation");

            builder.Property(x => x.Description)
                .HasColumnName("description");

            builder.Property(x => x.MineralTypeId)
                .HasColumnName("mineraltypeid");

            builder.Property(x => x.OriginId)
                .HasColumnName("originid");

            builder.Property(x => x.TypeId)
                .HasColumnName("typeid");

            builder.Property(x => x.SituationId)
                .HasColumnName("situationid");

            builder.Property(x => x.MiningUnitId)
                .HasColumnName("miningunitid");

            builder.Property(x => x.ConditionId)
                .HasColumnName("conditionid");

            builder.Property(x => x.StateManagementId)
                .HasColumnName("statemanagementid");

            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());

            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}