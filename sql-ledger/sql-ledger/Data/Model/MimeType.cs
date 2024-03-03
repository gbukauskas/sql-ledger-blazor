using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class MimeType
    {
        public string Extension { get; set; } = null;
        public string? ContentType { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<MimeType>();

            ent.HasKey(e => e.Extension).HasName("mimetype_pkey");
            ent.ToTable("mimetype");

            ent.Property(x => x.Extension).HasColumnName("extension")
                .HasColumnType("nvarchar(32)")
                .HasMaxLength(32);
            ent.Property(x => x.ContentType).HasColumnName("contenttype")
                .HasColumnType("nvarchar(64)");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
