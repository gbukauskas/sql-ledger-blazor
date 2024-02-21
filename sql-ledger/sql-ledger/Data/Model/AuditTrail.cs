using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class AuditTrail
    {
        public int? TransId { get; set; }
        public string? TableName { get; set; }
        public string? Reference { get; set; }
        public string? FormName { get; set; }
        public string? Action { get; set; }
        DateTime TransDate { get; set; }
        public int? EmployeeId { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<AuditTrail>();

            ent.HasNoKey();
            ent.ToTable("audittrail");

            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.TableName).HasColumnName("tablename")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Reference).HasColumnName("reference")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.FormName).HasColumnName("formname")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Action).HasColumnName("action")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.TransDate).HasColumnName("transdate")
                .HasDefaultValueSql<DateTime>("CAST(GETUTCDATE() AS Date)");
            ent.Property(x => x.EmployeeId).HasColumnName("employee_id");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.TransId).HasDatabaseName("audittrail_trans_id_key");
        }
    }
}
