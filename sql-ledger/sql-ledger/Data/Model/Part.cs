using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Part
    {
        public int Id { get; set; }
        public string? PartNumber { get; set; }
        public string? Description { get; set; }
        public string? Unit { get; set; }
        public decimal? ListPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? LastCost { get; set; }
        public DateTime PriceUpdate { get; set; }
        public decimal? Weight { get; set; }
        public decimal OnHand { get; set; }
        public string? Notes { get; set; }
        public bool MakeModel { get; set; }
        public bool Assembly { get; set; }
        public bool Alternate { get; set; }
        public decimal? Rop { get; set; }
        public int? InventoryAccnoId { get; set; }
        public int? IncomeAccnoId { get; set; }
        public int? ExpenseAccnoId { get; set; }
        public string? Bin { get; set; }
        public bool Obsolete { get; set; }
        public bool Bom { get; set; }
        public string? Image { get; set; }
        public string? Drawing { get; set; }
        public string? Microfiche { get; set; }
        public int? PartsGroupId { get; set; }
        public int? ProjectId { get; set; }
        public decimal? AvgCost { get; set; }
        public string? TariffHscode { get; set; }
        public string? CountryOrigin { get; set; }
        public string? BarCode { get; set; }
        public string? ToolNumber { get; set; }
        public string? Lot { get; set; }
        public DateTime Expires { get; set; }
        public bool CheckInventory { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {

            var ent = _builder.Entity<Part>();

            ent.HasNoKey();
            ent.ToTable("parts");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.PartNumber).HasColumnName("partnumber")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.Unit).HasColumnName("unit")
                .HasColumnType("nvarchar(5)")
                .HasMaxLength(5);
            ent.Property(x => x.ListPrice).HasColumnName("listprice")
                .HasPrecision(28, 6);
            ent.Property(x => x.SellPrice).HasColumnName("sellprice")
                .HasPrecision(28, 6);
            ent.Property(x => x.LastCost).HasColumnName("lastcost")
                .HasPrecision(28, 6);
            ent.Property(x => x.PriceUpdate).HasColumnName("priceupdate")
                .HasDefaultValueSql<DateTime>("GETUTCDATE()");
            ent.Property(x => x.Weight).HasColumnName("weight")
                .HasPrecision(28, 6);
            ent.Property(x => x.OnHand).HasColumnName("onhand")
                .HasPrecision(28, 6)
                .HasDefaultValue(0.0);
            ent.Property(x => x.Notes).HasColumnName("notes")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.MakeModel).HasColumnName("makemodel")
                .HasDefaultValue<bool>(false);
            ent.Property(x => x.Assembly).HasColumnName("assembly")
                .HasDefaultValue<bool>(false);
            ent.Property(x => x.Alternate).HasColumnName("alternate")
                .HasDefaultValue<bool>(false);
            ent.Property(x => x.Rop).HasColumnName("rop")
                .HasPrecision(28, 6);
            ent.Property(x => x.InventoryAccnoId).HasColumnName("inventory_accno_id");
            ent.Property(x => x.IncomeAccnoId).HasColumnName("income_accno_id");
            ent.Property(x => x.ExpenseAccnoId).HasColumnName("expense_accno_id");
            ent.Property(x => x.Bin).HasColumnName("bin")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Obsolete).HasColumnName("obsolete")
                .HasDefaultValue<bool>(false);
            ent.Property(x => x.Bom).HasColumnName("bom")
                .HasDefaultValue<bool>(false);
            ent.Property(x => x.Image).HasColumnName("image")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Drawing).HasColumnName("drawing")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Microfiche).HasColumnName("microfiche")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.PartsGroupId).HasColumnName("partsgroup_id");
            ent.Property(x => x.ProjectId).HasColumnName("project_id");
            ent.Property(x => x.AvgCost).HasColumnName("avgcost")
                .HasPrecision(28, 6);
            ent.Property(x => x.TariffHscode).HasColumnName("tariff_hscode")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.CountryOrigin).HasColumnName("countryorigin")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.BarCode).HasColumnName("barcode")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.ToolNumber).HasColumnName("toolnumber")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Lot).HasColumnName("lot")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Expires).HasColumnName("expires");
            ent.Property(x => x.CheckInventory).HasColumnName("checkinventory")
                .HasDefaultValue<bool>(false);

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.Id).HasDatabaseName("parts_id_key");
            ent.HasIndex(x => x.PartNumber).HasDatabaseName("parts_partnumber_key");
            ent.HasIndex(x => x.Description).HasDatabaseName("parts_description_key");
        }
    }
}
