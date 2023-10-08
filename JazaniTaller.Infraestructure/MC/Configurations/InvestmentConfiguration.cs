using JazaniTaller.Domain.MC.Models;
using JazaniTaller.Infraestructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JazaniTaller.Infraestructure.MC.Configurations
{
    public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            // Nombre de la tabla y esquema
            builder.ToTable("investment", "mc");

            // Clave primaria
            builder.HasKey(x => x.Id);

            // Mapeo de propiedades
            builder.Property(x => x.AmountInvested).HasColumnName("amountinvestd");
            builder.Property(x => x.Year).HasColumnName("year");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.MiningConcessionId).HasColumnName("miningconcessionid");
            builder.Property(x => x.InvestmentTypeId).HasColumnName("investmenttypeid");
            builder.Property(x => x.CurrencyTypeId).HasColumnName("currencytypeid");
            builder.Property(x => x.PeriodTypeId).HasColumnName("periodtypeid");
            builder.Property(x => x.MeasureUnitId).HasColumnName("measureunitid");
            builder.Property(t => t.RegistrationDate)
                 .HasColumnName("registrationdate")
                 .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(x => x.State).HasColumnName("state").HasDefaultValue(true);
            builder.Property(x => x.MonthName).HasColumnName("monthname");
            builder.Property(x => x.MonthId).HasColumnName("monthid");
            builder.Property(x => x.AccreditationCode).HasColumnName("accreditationcode");
            builder.Property(x => x.AccountantCode).HasColumnName("accountantcode");
            builder.Property(x => x.HolderId).HasColumnName("holderid");
            builder.Property(x => x.DeclaredTypeId).HasColumnName("declaredtypeid");
            builder.Property(x => x.DocumentId).HasColumnName("documentid");
            builder.Property(x => x.InvestmentConceptId).HasColumnName("investmentconceptid");
            builder.Property(x => x.Module).HasColumnName("module");
            builder.Property(x => x.Frecuency).HasColumnName("frecuency");
            builder.Property(x => x.IsDAC).HasColumnName("isdac");
            builder.Property(x => x.MetricTons).HasColumnName("metrictons");
            builder.Property(x => x.DeclarationDate).HasColumnName("declarationdate");

            builder.HasOne(one => one.Holder).WithMany(many => many.Investments).HasForeignKey(
                fk => fk.HolderId);
            builder.HasOne(one => one.InvestmentType).WithMany(many => many.Investments).HasForeignKey(
                fk => fk.InvestmentTypeId);
            builder.HasOne(one => one.PeriodType).WithMany(many => many.Investments).HasForeignKey(
                fk => fk.PeriodTypeId);
            builder.HasOne(one => one.MiningConcession).WithMany(many => many.Investments).HasForeignKey(
                fk => fk.MiningConcessionId);
            builder.HasOne(one => one.MeasureUnit).WithMany(many => many.Investments).HasForeignKey(
                fk => fk.MeasureUnitId);
        }
    }
}
