using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Contact { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string? Notes { get; set; }
        public short Terms { get; set; }
        public bool TaxIncluded { get; set; }
        public string? CustomerNumber { get; set; }
        public string? Cc { get; set; }
        public string? Bcc { get; set; }
        public int? BusinessId { get; set; }
        public string? TaxNumber { get; set; }
        public string? SicCode { get; set; }
        public float? Discount { get; set; }
        public decimal CreditLimit { get; set; }
        public int? EmployeeId { get; set; }
        public string? LanguageCode { get; set; }
        public int? PriceGroupId { get; set; }
        public string? Currency { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ArapAccNoId { get; set; }
        public int? PaymentAccNoId { get; set; }
        public int? DiscountAccNoId { get; set; }
        public float? CashDiscount { get; set; }
        public short? DiscountTerms { get; set; }
        public decimal? Threshold { get; set; }
        public int? PaymentMethodId { get; set; }
        public bool? RemittanceVoucher { get; set; }
        public int? PrepaymentAccnoId { get; set; }

        public List<Tax> Taxes { get; set; } = null!;
        public List<CustomerTax> CustomerTaxes { get; set; } = null!;

        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Customer>();

            ent.HasKey(x => x.Id).HasName("customer_pkey");
            ent.ToTable("customer");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.Name).HasColumnName("name")
                .HasColumnType("nvarchar(64)");
            ent.Property(x => x.Contact).HasColumnName("contact")
                .HasColumnType("nvarchar(64)");
            ent.Property(x => x.Phone).HasColumnName("phone")
                .HasColumnType("nvarchar(20)");
            ent.Property(x => x.Fax).HasColumnName("fax")
                .HasColumnType("nvarchar(20)");
            ent.Property(x => x.Email).HasColumnName("email")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Notes).HasColumnName("notes")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Terms).HasColumnName("terms")
                .HasDefaultValue(0);
            ent.Property(x => x.TaxIncluded).HasColumnName("taxincluded")
                .HasDefaultValue<bool>(false);
            ent.Property(x => x.CustomerNumber).HasColumnName("customernumber")
                .HasColumnType("nvarchar(32)");
            ent.Property(x => x.Cc).HasColumnName("cc")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Bcc).HasColumnName("bcc")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.BusinessId).HasColumnName("business_id");
            ent.Property(x => x.TaxNumber).HasColumnName("taxnumber")
                .HasColumnType("nvarchar(32)");
            ent.Property(x => x.SicCode).HasColumnName("sic_code")
                .HasColumnType("nvarchar(6)");
            ent.Property(x => x.Discount).HasColumnName("discount");
            ent.Property(x => x.CreditLimit).HasColumnName("creditlimit")
                .HasPrecision(28, 6)
                .HasDefaultValue(0);
            ent.Property(x => x.EmployeeId).HasColumnName("employee_id");
            ent.Property(x => x.LanguageCode).HasColumnName("language_code")
                .HasColumnType("nvarchar(6)")
                .HasMaxLength(6);
            ent.Property(x => x.PriceGroupId).HasColumnName("pricegroup_id");
            ent.Property(x => x.Currency).HasColumnName("curr")
                .HasColumnType("char(3)")
                .HasMaxLength(3);
            ent.Property(x => x.StartDate).HasColumnName("startdate");
            ent.Property(x => x.EndDate).HasColumnName("enddate");
            ent.Property(x => x.ArapAccNoId).HasColumnName("arap_accno_id");
            ent.Property(x => x.PaymentAccNoId).HasColumnName("payment_accno_id");
            ent.Property(x => x.DiscountAccNoId).HasColumnName("discount_accno_id");
            ent.Property(x => x.CashDiscount).HasColumnName("cashdiscount");
            ent.Property(x => x.DiscountTerms).HasColumnName("discountterms");
            ent.Property(x => x.Threshold).HasColumnName("threshold")
                .HasPrecision(28, 6);
            ent.Property(x => x.PaymentMethodId).HasColumnName("paymentmethod_id");
            ent.Property(x => x.RemittanceVoucher).HasColumnName("remittancevoucher");
            ent.Property(x => x.PrepaymentAccnoId).HasColumnName("prepayment_accno_id");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.Name).HasDatabaseName("customer_name_key");
            ent.HasIndex(x => x.CustomerNumber).HasDatabaseName("customer_number_key");
            ent.HasIndex(x => x.Contact).HasDatabaseName("customer_contact_key");
        }
    }

    public class CustomerTax
    {
        public int CustomerId {  get; set; }
        public int ChartId { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<CustomerTax>();

            ent.HasKey(x => new { x.CustomerId, x.ChartId }).HasName("customer_tax_pkey");
            ent.ToTable("customertax");

            ent.Property(x => x.CustomerId).HasColumnName("customer_id");
            ent.Property(x => x.ChartId).HasColumnName("chart_id");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }

    public class Tax
    {
        public int ChartId { get; set; }
        public decimal? Rate { get; set; }
        public string? TaxNumber { get; set; }
        public DateTime? ValidTo { get; set; }

        public List<Customer> Customers { get; set; } = null!;
        public List<CustomerTax> CustomerTaxes { get; set; } = null!;

        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Tax>();

            ent.HasKey(x => x.ChartId).HasName("tax_pkey");
            ent.ToTable("tax");

            ent.Property(x => x.ChartId).HasColumnName("chart_id");
            ent.Property(x => x.Rate).HasColumnName("rate")
                .HasPrecision(28, 6);
            ent.Property(x => x.TaxNumber).HasColumnName("taxnumber")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.ValidTo).HasColumnName("validto");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasMany(t => t.Customers)
                .WithMany(c => c.Taxes)
                .UsingEntity<CustomerTax>(
                    l => l.HasOne<Customer>().WithMany(c => c.CustomerTaxes),
                    r => r.HasOne<Tax>().WithMany(t => t.CustomerTaxes)
                );
        }
    }
}
