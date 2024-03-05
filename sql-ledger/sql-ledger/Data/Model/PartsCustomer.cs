using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class PartsCustomer
    {
        public int? PartsId { get; set; }
        public int? CustomerId { get; set; }
        public int? PriceGroupId { get; set; }
        public decimal? PriceBreak { get; set; }
        public decimal? SellPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Currency { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<PartsCustomer>();

            ent.HasNoKey();
            ent.ToTable("partscustomer");

            ent.Property(x => x.PartsId).HasColumnName("parts_id");
            ent.Property(x => x.CustomerId).HasColumnName("customer_id");
            ent.Property(x => x.PriceGroupId).HasColumnName("pricegroup_id");
            ent.Property(x => x.PriceBreak).HasColumnName("pricebreak")
                .HasPrecision(28, 6);
            ent.Property(x => x.SellPrice).HasColumnName("sellprice")
                .HasPrecision(28, 6);
            ent.Property(x => x.StartDate).HasColumnName("validfrom");
            ent.Property(x => x.EndDate).HasColumnName("validto");
            ent.Property(x => x.Currency).HasColumnName("curr")
                .HasColumnType("char(3)")
                .HasMaxLength(3);

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.PartsId).HasDatabaseName("partscustomer_parts_id_key");
            ent.HasIndex(x => x.CustomerId).HasDatabaseName("partscustomer_customer_id_key");
        }
    }
}
