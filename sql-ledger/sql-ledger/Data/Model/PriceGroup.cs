using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class PriceGroup
    {
        public int Id { get; set; }
        public string? Price_Group { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<PriceGroup>();

            ent.HasNoKey();
            ent.ToTable("pricegroup");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.Price_Group).HasColumnName("pricegroup")
                .HasColumnType("nvarchar(4000)");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.Id).HasDatabaseName("pricegroup_id_key");
            ent.HasIndex(x => x.Price_Group).HasDatabaseName("pricegroup_pricegroup_key");
        }
    }
}
