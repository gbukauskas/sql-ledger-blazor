using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class PartsGroup
    {
        public int Id { get; set; }
        public string? PartsGroupId { get; set; }
        public bool Pos { get; set; }
        public string? Code { get; set; }
        public string? Image { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<PartsGroup>();

            ent.HasNoKey();
            ent.ToTable("partsgroup");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.PartsGroupId).HasColumnName("partsgroup")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.Pos).HasColumnName("pos")
                .HasDefaultValue(true);
            ent.Property(x => x.Code).HasColumnName("code")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Image).HasColumnName("image")
                .HasColumnType("nvarchar(MAX)");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.Id).HasDatabaseName("partsgroup_id_key")
                .IsUnique(true);
            ent.HasIndex(x => x.PartsGroupId).HasDatabaseName("partsgroup_key");

        }
    }
}
