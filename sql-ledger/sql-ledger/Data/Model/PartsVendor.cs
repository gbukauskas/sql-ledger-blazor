using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class PartsVendor
    {
        public int? VendorId { get; set; }
        public int? PartsId { get; set; }
        public string? PartNumber { get; set; }
        public short? LeadTime { get; set; }
        public decimal? LastCost { get; set; }
        public string? Currency { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<PartsVendor>();

            ent.HasNoKey();
            ent.ToTable("partsvendor");

            ent.Property(x => x.VendorId).HasColumnName("vendor_id");
            ent.Property(x => x.PartsId).HasColumnName("parts_id");
            ent.Property(x => x.PartNumber).HasColumnName("partnumber")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.LeadTime).HasColumnName("leadtime");
            ent.Property(x => x.LastCost).HasColumnName("lastcost")
                .HasPrecision(28, 6);
            ent.Property(x => x.Currency).HasColumnName("curr")
                .HasColumnType("char(3)")
                .HasMaxLength(3);

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.PartsId).HasDatabaseName("partsvendor_parts_id_key");
            ent.HasIndex(x => x.VendorId).HasDatabaseName("partsvendor_vendor_id_key");
        }
    }
}
