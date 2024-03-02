using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class MakeModel
    {
        public int? PartsId { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<MakeModel>();

            ent.HasNoKey();
            ent.ToTable("makemodel");

            ent.Property(x => x.PartsId).HasColumnName("parts_id");
            ent.Property(x => x.Make).HasColumnName("make")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.Model).HasColumnName("model")
                .HasColumnType("nvarchar(4000)");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.PartsId).HasDatabaseName("makemodel_parts_id_key");
            ent.HasIndex(x => x.Make).HasDatabaseName("makemodel_make_key");
            ent.HasIndex(x => x.Model).HasDatabaseName("makemodel_model_key");
        }
    }
}
