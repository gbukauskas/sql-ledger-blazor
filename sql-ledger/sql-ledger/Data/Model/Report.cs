using Microsoft.EntityFrameworkCore;
using System.Composition;

namespace sql_ledger.Data.Model
{
    public class Report
    {
        public int ReportId { get; set; }
        public string? ReportCode { get; set; }
        public string? ReportDescription { get; set; }
        public string? Login { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Report>();

            ent.HasKey(e => e.ReportId).HasName("report_pkey");
            ent.ToTable("report");

            ent.Property(x => x.ReportId).HasColumnName("reportid")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.ReportCode).HasColumnName("reportcode")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.ReportDescription).HasColumnName("reportdescription")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Login).HasColumnName("login")
                .HasColumnType("nvarchar(MAX)");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
