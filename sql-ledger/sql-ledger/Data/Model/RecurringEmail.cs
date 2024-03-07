using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class RecurringEmail
    {
        public int? Id { get; set; }
        public string? FormName { get; set; }
        public string? Format { get; set; }
        public string? Message { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<RecurringEmail>();

            ent.HasNoKey();
            ent.ToTable("recurringemail");

            ent.Property(x => x.Id).HasColumnName("id");
            ent.Property(x => x.FormName).HasColumnName("formname")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Format).HasColumnName("format")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Message).HasColumnName("message")
                .HasColumnType("nvarchar(MAX)");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
