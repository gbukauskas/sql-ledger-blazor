using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Department
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public char Role { get; set; }
        public int? Rn { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Department>();

            ent.HasKey(d => d.Id).HasName("department_id_key");
            ent.ToTable("department");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Role).HasColumnName("role")
                .HasColumnType("char")
                .HasDefaultValue('P');
            ent.Property(x => x.Rn).HasColumnName("rn");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }

    public class DptTrans
    {
        public required int TransId { get; set; }
        public required int DepartmentId { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public Department? Department { get; set; }

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<DptTrans>();

            ent.HasNoKey();
            ent.ToTable("dpt_trans");

            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.DepartmentId).HasColumnName("department_id");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId)
                .HasConstraintName("department_department_id_fkey")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            ent.HasIndex(x => x.DepartmentId).HasDatabaseName("dpt_trans_department_id_key");

        }
    }
}