using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Br

    {
        public int Id { get; set; }
        public string? BatchNumber { get; set; }
        public string? Description { get; set; }
        public string? Batch { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime? ApprDate { get; set; }
        decimal? Amount { get; set; }
        public int? ManagerId { get; set; }
        public int? EmployeeId { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder) 
        {
            var ent = _builder.Entity<Br>();

            ent.HasKey(x => x.Id).HasName("br_pkey");
            ent.ToTable("br");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id"); ;
            ent.Property(x => x.BatchNumber).HasColumnName("batchnumber")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Batch).HasColumnName("batch")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.TransDate).HasColumnName("transdate")
                .HasDefaultValueSql<DateTime>("GETUTCDATE()");
            ent.Property(x => x.ApprDate).HasColumnName("apprdate");
            ent.Property(x => x.Amount).HasColumnName("amount")
                .HasPrecision(28, 6);
            ent.Property(x => x.ManagerId).HasColumnName("managerid");
            ent.Property(x => x.EmployeeId).HasColumnName("employee_id");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }

    public class Vr
    {
        public int? BrId { get; set; }
        int TransId { get; set; }
        public int Id { get; set; }
        public string? VoucherNumber { get; set; }
        public Br? Br { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Vr>();

            ent.HasNoKey();
            ent.ToTable("vr");

            ent.Property(x => x.BrId).HasColumnName("br_id");
            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.VoucherNumber).HasColumnName("vouchernumber")
                .HasColumnType("nvarchar(MAX)");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasOne(e => e.Br)
                .WithMany()
                .HasForeignKey(e => e.BrId)
                .HasConstraintName("vr_br_id_fkey")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
