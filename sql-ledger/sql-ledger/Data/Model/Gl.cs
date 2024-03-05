using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Gl
    {
        public int Id { get; set; }
        public string? Reference { get; set; }
        public string? Description { get; set; }
        public DateTime TransDate { get; set; }
        public int? EmployeeId { get; set; }
        public string? Notes { get; set; }
        public int? DepartmentId { get; set; }
        public bool? Approved { get; set; }
        public string? Currency { get; set; }
        public double? ExchangeRate { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Gl>();

            ent.HasKey(g => g.Id).HasName("gl_id_key");
            ent.ToTable("gl");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.Reference).HasColumnName("reference")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.TransDate).HasColumnName("transdate")
                .HasDefaultValueSql<DateTime>("GETUTCDATE()");
            ent.Property(x => x.EmployeeId).HasColumnName("employee_id");
            ent.Property(x => x.DepartmentId).HasColumnName("department_id")
                .HasDefaultValue(0);
            ent.Property(x => x.Approved).HasColumnName("approved")
                .HasDefaultValue(true);
            ent.Property(x => x.Notes).HasColumnName("notes")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Currency).HasColumnName("curr")
                .HasColumnType("char(3)")
                .HasMaxLength(3);
            ent.Property(x => x.ExchangeRate).HasColumnName("exchangerate")
                .HasColumnType("float");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(ent => ent.Description)
                .HasDatabaseName("gl_description_key");
            ent.HasIndex(x => x.EmployeeId)
                .HasDatabaseName("gl_employee_id_key");
            ent.HasIndex(ent => ent.Reference)
                .HasDatabaseName("gl_reference_key");
            ent.HasIndex(ent => ent.TransDate)
                .HasDatabaseName("gl_transdate_key");
        }
    }
}
