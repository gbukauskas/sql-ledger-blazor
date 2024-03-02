using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Wage
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal? Amount { get; set; }
        public int? Defer { get; set; }
        public bool Exempt { get; set; }
        public int ChartId { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Wage>();

            ent.HasKey(x => x.Id).HasName("wage_pkey");
            ent.ToTable("wage");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id"); ;
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Amount).HasColumnName("amount")
                .HasPrecision(28, 6);
            ent.Property(x => x.Defer).HasColumnName("defer");
            ent.Property(x => x.Exempt).HasColumnName("exempt")
                .HasDefaultValue(false);
            ent.Property(x => x.ChartId).HasColumnName("chart_id");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }

    public class EmployeeWage
    {
        public int? Id { get; set; }
        public required int EmployeeId { get; set; }
        public required int WageId { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<EmployeeWage>();

            ent.HasNoKey();
            ent.ToTable("employeewage");

            ent.Property(x => x.Id).HasColumnName("id");
            ent.Property(x => x.EmployeeId).HasColumnName("employee_id");
            ent.Property(x => x.WageId).HasColumnName("wage_id");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }

}
