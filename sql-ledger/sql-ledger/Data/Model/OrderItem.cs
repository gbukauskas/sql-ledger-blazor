using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int? TransId { get; set; }
        public int? PartsId { get; set; }
        public string? Description { get; set; }
        public decimal? Qty { get; set; }
        public decimal? SellPrice { get; set; }
        public float? Discount { get; set; }
        public string? Unit { get; set; }
        public int? ProjectId { get; set; }
        public DateTime ReqDate { get; set; }
        public decimal? Ship { get; set; }
        public string? SerialNumber { get; set; }
        public string? ItemNotes { get; set; }
        public bool? LineItemDetail { get; set; }
        public string? OrderNumber { get; set; }
        public string? PoNumber { get; set; }
        public decimal? Cost { get; set; }
        public string? Vendor { get; set; }
        public int? VendorId { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            _builder.HasSequence<int>("orderitems_id")
                .StartsAt(1)
                .IncrementsBy(1);

            var ent = _builder.Entity<OrderItem>();

            ent.HasKey(e => e.Id).HasName("orderitems_id_pkey");
            ent.ToTable("orderitems");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR orderitems_id");
            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.PartsId).HasColumnName("parts_id");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Qty).HasColumnName("qty")
                .HasPrecision(28, 6);
            ent.Property(x => x.SellPrice).HasColumnName("sellprice")
                .HasPrecision(28, 6);
            ent.Property(x => x.Discount).HasColumnName("discount");
            ent.Property(x => x.Unit).HasColumnName("unit")
                .HasColumnType("nvarchar(5)")
                .HasMaxLength(5);
            ent.Property(x => x.ProjectId).HasColumnName("project_id");
            ent.Property(x => x.ReqDate).HasColumnName("reqdate");
            ent.Property(x => x.Ship).HasColumnName("ship")
                .HasPrecision(28, 6);
            ent.Property(x => x.SerialNumber).HasColumnName("serialnumber")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.ItemNotes).HasColumnName("itemnotes")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.LineItemDetail).HasColumnName("lineitemdetail");
            ent.Property(x => x.OrderNumber).HasColumnName("ordernumber")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.PoNumber).HasColumnName("ponumber")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Cost).HasColumnName("cost")
                .HasPrecision(28, 6);
            ent.Property(x => x.Vendor).HasColumnName("vendor")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.VendorId).HasColumnName("vendor_id");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.TransId).HasDatabaseName("orderitems_trans_id_key");
        }
    }
}
