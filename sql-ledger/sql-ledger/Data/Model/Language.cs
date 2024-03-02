using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Language
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
        public bool IsRtl { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Language>();

            ent.HasKey(x => x.Code).HasName("language_code_key");
            ent.ToTable("language");

            ent.Property(x => x.Code).HasColumnName("code")
                .HasColumnType("nvarchar(6)")
                .HasMaxLength(6);
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.IsRtl).HasColumnName("rtl")
                .HasDefaultValue(false);

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
