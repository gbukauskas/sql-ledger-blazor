using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace sql_ledger.Data.Model
{
    public class Ar
    {
        public int Id { get; set; }
        public string? InvNumber { get; set; }
        public DateTime TransDate { get; set; }
        public int? CustomerId { get; set; }
        public bool? TaxIncluded { get; set; }
        public decimal? Amount { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? Paid { get; set; }
        public DateTime? DatePaid { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Invoice { get; set; }
        public string? ShippingPoint { get; set; }
        public short Terms { get; set; }
        public string? Notes { get; set; }
        public string? Curr { get; set; }
        public string? OrdNumber { get; set; }
        public int? EmployeeId { get; set; }
        public string? Till { get; set; }
        public string? QuoNumber { get; set; }
        public string? IntNotes { get; set; }
        public int? DepartmentId { get; set; }
        public string? ShipVia { get; set; }
        public string? LanguageCode { get; set; }
        public string? PoNumber { get; set; }
        public bool? Approved { get; set; }
        public float? CashDiscount { get; set; }
        public short? DiscountTerms { get; set; }
        public string? WayBill { get; set; }
        public int? WarehouseId { get; set; }
        public string? Description { get; set; }
        public bool? OnHold { get; set; }
        public double? ExchangeRate { get; set; }
        public string? Dcn { get; set; }
        public int? BankId { get; set; }
        public int? PaymentMethodId { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Ar>();

            ent.HasNoKey();
            ent.ToTable("ar");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.InvNumber).HasColumnName("invnumber")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.TransDate).HasColumnName("transdate")
                .HasDefaultValueSql<DateTime>("GETUTCDATE()");
            ent.Property(x => x.CustomerId).HasColumnName("customer_id");
            ent.Property(x => x.TaxIncluded).HasColumnName("taxincluded");
            ent.Property(x => x.Amount).HasColumnName("amount")
                .HasPrecision(28, 6);
            ent.Property(x => x.NetAmount).HasColumnName("netamount")
                .HasPrecision(28, 6);
            ent.Property(x => x.Paid).HasColumnName("paid")
                .HasPrecision(28, 6);
            ent.Property(x => x.DatePaid).HasColumnName("datepaid");
            ent.Property(x => x.DueDate).HasColumnName("duedate");
            ent.Property(x => x.Invoice).HasColumnName("invoice")
                .HasDefaultValue<bool>(false);
            ent.Property(x => x.ShippingPoint).HasColumnName("shippingpoint")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Terms).HasColumnName("terms")
                .HasDefaultValue(0);
            ent.Property(x => x.Notes).HasColumnName("notes")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Curr).HasColumnName("curr")
                .HasColumnType("char(3)")
                .HasMaxLength(3);
            ent.Property(x => x.OrdNumber).HasColumnName("ordnumber")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.EmployeeId).HasColumnName("employee_id");
            ent.Property(x => x.Till).HasColumnName("till")
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20);
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
            ent.Property(x => x.Approved).HasColumnName("approved")
                .HasDefaultValue(true);
            ent.Property(x => x.CashDiscount).HasColumnName("cashdiscount");
            ent.Property(x => x.DiscountTerms).HasColumnName("discountterms");
            ent.Property(x => x.WayBill).HasColumnName("waybill")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.WarehouseId).HasColumnName("warehouse_id");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.OnHold).HasColumnName("onhold")
                .HasDefaultValue(false);
            ent.Property(x => x.ExchangeRate).HasColumnName("exchangerate")
                .HasColumnType("float");
            ent.Property(x => x.Dcn).HasColumnName("dcn")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.BankId).HasColumnName("bank_id");
            ent.Property(x => x.PaymentMethodId).HasColumnName("paymentmethod_id");

            ent.HasIndex(x => x.CustomerId).HasDatabaseName("ar_customer_id_key");
            ent.HasIndex(x => x.EmployeeId).HasDatabaseName("ar_employee_id_key");
            ent.HasIndex(x => x.Id).HasDatabaseName("ar_id_key");
            ent.HasIndex(x => x.InvNumber).HasDatabaseName("ar_invnumber_key");
            ent.HasIndex(x => x.OrdNumber).HasDatabaseName("ar_ordnumber_key");
            ent.HasIndex(x => x.QuoNumber).HasDatabaseName("ar_quonumber_key");
            ent.HasIndex(x => x.TransDate).HasDatabaseName("ar_transdate_key");
        }
    }
}
