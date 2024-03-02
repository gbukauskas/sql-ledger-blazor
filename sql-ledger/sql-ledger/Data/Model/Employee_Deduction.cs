using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace sql_ledger.Data.Model
{
    public class Employee
    {
        public required int Id { get; set; }
        public string? Login { get; set; }
        public string? Name { get; set; }
        public string? WorkPhone { get; set; }
        public string? WorkFax { get; set; }
        public string? WorkMobile { get; set; }
        public string? HomePhone { get; set; }
        public string? HomeMobile { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Notes { get; set; }
        public bool Sales { get; set; }
        public string? Email { get; set; }
        public string? Ssn { get; set; }
        public string? EmployeeNumber { get; set; }
        public DateTime? Dob { get; set; }
        public short PayPeriod { get; set; }
        public int? ApId { get; set; }
        public int? PaymentId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? AcsRoleId { get; set; }
        public string? Acs { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Employee>();

            ent.HasKey(d => d.Id).HasName("employee_pkey");
            ent.ToTable("employee");
            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.Login).HasColumnName("login")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.Name).HasColumnName("name")
                .HasColumnType("nvarchar(64)");
            ent.Property(x => x.WorkPhone).HasColumnName("workphone")
                .HasColumnType("nvarchar(20)");
            ent.Property(x => x.WorkFax).HasColumnName("workfax")
                .HasColumnType("nvarchar(20)");
            ent.Property(x => x.WorkMobile).HasColumnName("workmobile")
                .HasColumnType("nvarchar(20)");
            ent.Property(x => x.HomePhone).HasColumnName("homephone")
                .HasColumnType("nvarchar(20)");
            ent.Property(x => x.HomeMobile).HasColumnName("homemobile")
                .HasColumnType("nvarchar(20)");
            ent.Property(x => x.StartDate).HasColumnName("startdate")
                .HasDefaultValueSql<DateTime>("GETUTCDATE()");
            ent.Property(x => x.EndDate).HasColumnName("enddate");
            ent.Property(x => x.Notes).HasColumnName("notes")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Sales).HasColumnName("sales")
                .HasDefaultValue<bool>(false);
            ent.Property(x => x.Email).HasColumnName("email")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Ssn).HasColumnName("ssn")
                .HasColumnType("nvarchar(20)");
            ent.Property(x => x.EmployeeNumber).HasColumnName("employeenumber")
                .HasColumnType("nvarchar(20)");
            ent.Property(x => x.Dob).HasColumnName("dob");
            ent.Property(x => x.PayPeriod).HasColumnName("payperiod");
            ent.Property(x => x.ApId).HasColumnName("apid");
            ent.Property(x => x.PaymentId).HasColumnName("paymentid");
            ent.Property(x => x.PaymentMethodId).HasColumnName("paymentmethod_id");
            ent.Property(x => x.AcsRoleId).HasColumnName("acsrole_id");
            ent.Property(x => x.Acs).HasColumnName("acs")
                .HasColumnType("nvarchar(MAX)");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.Login).HasDatabaseName("employee_login_key")
                .IsUnique(true);
            ent.HasIndex(x => x.Name).HasDatabaseName("employee_name_key");

        }
    }

    public class EmployeeDeduction
    {
        public int? Id { get; set; }
        public required int EmployeeId { get; set; }
        public int? DeductionId { get; set; }
        public decimal? Exempt { get; set; }
        public decimal? Maximum { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public Employee? Employee { get; set; }

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<EmployeeDeduction>();

            ent.HasNoKey();
            ent.ToTable("employeededuction");

            ent.Property(x => x.Id).HasColumnName("id");
            ent.Property(x => x.EmployeeId).HasColumnName("employee_id");
            ent.Property(x => x.DeductionId).HasColumnName("deduction_id");
            ent.Property(x => x.Exempt).HasColumnName("exempt")
                .HasPrecision(28, 6);
            ent.Property(x => x.Maximum).HasColumnName("maximum")
                .HasPrecision(28, 6);

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasOne(e => e.Employee)
                .WithMany()
                .HasForeignKey(e => e.EmployeeId)
                .HasConstraintName("employee_employee_id_fkey")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}