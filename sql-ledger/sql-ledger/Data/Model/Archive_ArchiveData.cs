using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Archive
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            _builder.HasSequence<int>("archive_id")
                .StartsAt(1)
                .IncrementsBy(1);

            var ent = _builder.Entity<Archive>();

            ent.HasKey(x => x.Id).HasName("archive_pkey");
            ent.ToTable("archive");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR archive_id");
            ent.Property(x => x.FileName).HasColumnName("filename")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }

    public class ArchiveData
    {
        public int? ArchiveId { get; set; }
        public string? Bt { get; set; }
        public int? Rn { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public Archive Archive { get; set; } = null!;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<ArchiveData>();

            ent.HasNoKey();
            ent.ToTable("archivedata");

            ent.Property(x => x.ArchiveId).HasColumnName("archive_id");
            ent.Property(x => x.Rn).HasColumnName("rn");
            ent.Property(x => x.Bt).HasColumnName("bt")
                .HasColumnType("nvarchar(MAX)");
            
            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasOne(e => e.Archive)
                .WithMany()
                .HasForeignKey(e => e.ArchiveId)
                .HasConstraintName("archivedata_archive_id_fkey")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
