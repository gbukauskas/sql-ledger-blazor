using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Reference
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public int? TransId { get; set; }
        public string? Description { get; set; }
        public int? ArchiveId { get; set; }
        public string? Login { get; set; }
        public string? FormName { get; set; }
        public string? Folder { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            _builder.HasSequence<int>("reference_id")
                .StartsAt(1)
                .IncrementsBy(1);

            var ent = _builder.Entity<Reference>();

            ent.HasKey(r => r.Id).HasName("reference_pkey");
            ent.ToTable("reference");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR reference_id");
            ent.Property(x => x.Code).HasColumnName("code")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.ArchiveId).HasColumnName("archive_id");
            ent.Property(x => x.Login).HasColumnName("login")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.FormName).HasColumnName("formname")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Folder).HasColumnName("folder")
                .HasColumnType("nvarchar(MAX)");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

        }
    }
}
