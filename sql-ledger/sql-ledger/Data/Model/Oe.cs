using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Oe
    {
        public int Id { get; set; }
        public string? OrdNumber { get; set; }
        public DateTime TransDate { get; set; }
        public int? VendorId { get; set; }
        public int? CustomerId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? NetAmount { get; set; }
        public DateTime ReqDate { get; set; }
        public bool TaxIncluded { get; set; }
        public string? ShippingPoint { get; set; }
        public string? Notes { get; set; }
        public string? Currency { get; set; }
        public int? EmployeeId { get; set; }
        public bool? Closed { get; set; }
        public bool? Quotation  { get; set; }
        public string? QuoNumber { get; set; }
        public string? IntNotes { get; set; }
        public int? DepartmentId { get; set; }
        public string? ShipVia { get; set; }
        public string? LanguageCode { get; set; }
        public string? PoNumber { get; set; }
        public short Terms { get; set; }
        public string? WayBill { get; set; }
        public int? WarehouseId { get; set; }
        public string? Description { get; set; }
        public int? AaId { get; set; }
        public double? ExchangeRate { get; set; }
        public bool? BackOrder { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Oe>();

            ent.HasNoKey();
            ent.ToTable("oe");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.OrdNumber).HasColumnName("ordnumber")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.TransDate).HasColumnName("transdate")
                .HasDefaultValueSql<DateTime>("GETUTCDATE()");
            ent.Property(x => x.VendorId).HasColumnName("vendor_id");
            ent.Property(x => x.CustomerId).HasColumnName("customer_id");
            ent.Property(x => x.Amount).HasColumnName("amount")
                .HasPrecision(28, 6);
            ent.Property(x => x.NetAmount).HasColumnName("netamount")
                .HasPrecision(28, 6);
            ent.Property(x => x.ReqDate).HasColumnName("reqdate");
            ent.Property(x => x.TaxIncluded).HasColumnName("taxincluded");
            ent.Property(x => x.ShippingPoint).HasColumnName("shippingpoint")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Notes).HasColumnName("notes")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Currency).HasColumnName("curr")
                .HasColumnType("char(3)")
                .HasMaxLength(3);
            ent.Property(x => x.EmployeeId).HasColumnName("employee_id");
            ent.Property(x => x.Closed).HasColumnName("closed")
                .HasDefaultValue(false);
            ent.Property(x => x.Quotation).HasColumnName("quotation")
                .HasDefaultValue(false);
            ent.Property(x => x.QuoNumber).HasColumnName("quonumber")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.IntNotes).HasColumnName("intnotes")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.DepartmentId).HasColumnName("department_id")
                .HasDefaultValue(0);
            ent.Property(x => x.ShipVia).HasColumnName("shipvia")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.LanguageCode).HasColumnName("language_code")
                .HasColumnType("nvarchar(6)")
                .HasMaxLength(6);
            ent.Property(x => x.PoNumber).HasColumnName("ponumber")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Terms).HasColumnName("terms")
                .HasDefaultValue(0);
            ent.Property(x => x.WayBill).HasColumnName("waybill")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.WarehouseId).HasColumnName("warehouse_id");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.AaId).HasColumnName("aa_id");
            ent.Property(x => x.ExchangeRate).HasColumnName("exchangerate")
                .HasColumnType("float");
            ent.Property(x => x.BackOrder).HasColumnName("backorder")
                .HasDefaultValue(false);

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.Id).HasDatabaseName("oe_id_key");
            ent.HasIndex(x => x.OrdNumber).HasDatabaseName("oe_ordnumber_key");
            ent.HasIndex(x => x.TransDate).HasDatabaseName("oe_transdate_key");
            ent.HasIndex(x => x.EmployeeId).HasDatabaseName("oe_employee_id_key");
        }
    }
}
