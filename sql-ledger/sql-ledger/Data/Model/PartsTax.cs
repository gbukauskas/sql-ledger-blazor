using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class PartsTax
    {
        public int? PartsId { get; set; }
        public int? ChartId { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<PartsTax>();

            ent.HasNoKey();
            ent.ToTable("partstax");

            ent.Property(x => x.PartsId).HasColumnName("parts_id");
            ent.Property(x => x.ChartId).HasColumnName("chart_id");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.PartsId).HasDatabaseName("partstax_parts_id_key");
        }
    }
}
