using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql_ledger.Data.Model
{
    public class Deduction
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? EmployeeAccnoId { get; set; }
        public decimal? EmployeePays { get; set; }
        public int? EmployerAccnoId { get; set; }
        public decimal? EmployerPays { get; set; }
        public short? FromAge { get; set; }
        public short? ToAge { get; set; }

        public bool? AgeDob { get; set; }
        public int? BaseDon { get; set; }

        public List<DeductionRate> TaxDeductionRates { get; set; } = null!;
        public List<DeductionDeductionRate> DeductionDeductionRates { get; set; } = null!;

        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Deduction>();

            ent.HasKey(x => x.Id).HasName("deduction_pkey");
            ent.ToTable("deduction");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.EmployeeAccnoId).HasColumnName("employee_accno_id");
            ent.Property(x => x.EmployeePays).HasColumnName("employeepays")
                .HasPrecision(28, 6);
            ent.Property(x => x.EmployerAccnoId).HasColumnName("employer_accno_id");
            ent.Property(x => x.EmployerPays).HasColumnName("employerpays")
                .HasPrecision(28, 6);
            ent.Property(x => x.FromAge).HasColumnName("fromage");
            ent.Property(x => x.ToAge).HasColumnName("toage");

            ent.Property(x => x.AgeDob).HasColumnName("agedob");
            ent.Property(x => x.BaseDon).HasColumnName("basedon");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }

    public class DeductionDeductionRate
    {
        public int TransId { get; set; }
        public int DeductionId { get; set; }
        public bool? WithHolding { get; set; }
        public float? Percent { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<DeductionDeductionRate>();

            ent.HasKey(x => new { x.TransId, x.DeductionId }).HasName("deduct_pkey");
            ent.ToTable("deduct");

            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.DeductionId).HasColumnName("deduction_id");
            ent.Property(x => x.WithHolding).HasColumnName("withholding");
            ent.Property(x => x.Percent).HasColumnName("percent");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }

    public class DeductionRate
    {
        public short? Rn { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransId { get; set; }

        public decimal? Rate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Above { get; set; }
        public decimal? Below { get; set; }

        public List<Deduction> Deductions { get; set; } = null!;
        public List<DeductionDeductionRate> DeductionDeductionRates { get; set; } = null!;

        public byte[]? RowVersion { get; set; } = null;


        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<DeductionRate>();

            ent.HasKey(x => x.TransId).HasName("deductionrate_pkey");
            ent.ToTable("deductionrate");

            ent.Property(x => x.Rn).HasColumnName("rn");
            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.Rate).HasColumnName("rate")
                .HasPrecision(28, 6);
            ent.Property(x => x.Amount).HasColumnName("amount")
                .HasPrecision(28, 6);
            ent.Property(x => x.Above).HasColumnName("above")
                .HasPrecision(28, 6);
            ent.Property(x => x.Below).HasColumnName("below")
                .HasPrecision(28, 6);


            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasMany(t => t.Deductions)
                .WithMany(c => c.TaxDeductionRates)
                .UsingEntity<DeductionDeductionRate>(
                    l => l.HasOne<Deduction>().WithMany(c => c.DeductionDeductionRates)
                            .HasForeignKey(c => c.TransId),
                    r => r.HasOne<DeductionRate>().WithMany(t => t.DeductionDeductionRates)
                            .HasForeignKey(t => t.DeductionId)
                );

        }
    }
}
