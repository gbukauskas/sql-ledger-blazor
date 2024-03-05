using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sql_ledger.Data.Model;

namespace sql_ledger.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Acc_trans> AccTransactions { get; set; }
        public DbSet<AcsRole> AcsRoles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Ap> Aps { get; set; }
        public DbSet<Ar> Ars { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<ArchiveData> ArchiveDatas { get; set; }
        public DbSet<Assembly> Assemblies { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Br> Brs { get; set; }
        public DbSet<Vr> Vrs { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Chart> Charts { get; set; }
        public DbSet<Gifi> Gifies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<CustomerTax> CustomerTaxes { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
        public DbSet<DeductionRate> DeductionRates { get; set; }
        public DbSet<DeductionDeductionRate> DeductionDeductionRates { get; set; }
        public DbSet<Default> Defaults { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DptTrans> DptTransactions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDeduction> EmployeeDeductiones { get; set; }
        public DbSet<Wage> Wages { get; set; }
        public DbSet<EmployeeWage> EmployeeWages { get; set; }
        public DbSet<Gl> Gls { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<JcItem> JcItems { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MakeModel> MakeModels { get; set; }
        public DbSet<MimeType> MimeTypes { get; set; }
        public DbSet<Oe> Oes { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartsCustomer> PartsCustomers { get; set; }
        public DbSet<PartsGroup> PartsGroups { get; set; }
        public DbSet<PartsTax> PartsTaxes { get; set; }
        public DbSet<PartsVendor> PartsVendors { get; set; }
        public DbSet<PayTrans> PayTranses { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasSequence<int>("public_id")
                .StartsAt(10000)
                .IncrementsBy(1);
            builder.HasSequence<int>("address_id")
                .StartsAt(1)
                .IncrementsBy(1);

            Acc_trans.Configure(builder);
            AcsRole.Configure(builder);
            Address.Configure(builder);
            Ap.Configure(builder);
            Ar.Configure(builder);
            Archive.Configure(builder);
            ArchiveData.Configure(builder);
            Assembly.Configure(builder);
            AuditTrail.Configure(builder);
            Bank.Configure(builder);
            Br.Configure(builder);
            Vr.Configure(builder);
            Business.Configure(builder);
            Cargo.Configure(builder);
            Chart.Configure(builder);
            Gifi.Configure(builder);
            Contact.Configure(builder);
            Currency.Configure(builder);
            ExchangeRate.Configure(builder);
            Customer.Configure(builder);
            Tax.Configure(builder);
            CustomerTax.Configure(builder);
            Deduction.Configure(builder);
            DeductionRate.Configure(builder);
            DeductionDeductionRate.Configure(builder);
            Default.Configure(builder);
            Department.Configure(builder);
            DptTrans.Configure(builder);
            Employee.Configure(builder);
            EmployeeDeduction.Configure(builder);
            Wage.Configure(builder);
            EmployeeWage.Configure(builder);
            Gl.Configure(builder);
            Inventory.Configure(builder);
            Invoice.Configure(builder);
            JcItem.Configure(builder);
            Language.Configure(builder);
            MakeModel.Configure(builder);
            MimeType.Configure(builder);
            Oe.Configure(builder);
            OrderItem.Configure(builder);
            Part.Configure(builder);
            PartsCustomer.Configure(builder);
            PartsGroup.Configure(builder);
            PartsTax.Configure(builder);
            PartsVendor.Configure(builder);
            PayTrans.Configure(builder);
            Payment.Configure(builder);
        }
    }
}
