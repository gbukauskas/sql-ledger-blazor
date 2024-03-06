using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string? ProjectNumber { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PartsId { get; set; }
        public decimal Production { get; set; }
        public decimal Completed { get; set; }
        public int? CustomerId { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Project>();

            ent.HasKey(e => e.Id).HasName("project_id_key");
            ent.ToTable("project");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.ProjectNumber).HasColumnName("projectnumber")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.StartDate).HasColumnName("startdate");
            ent.Property(x => x.EndDate).HasColumnName("enddate");
            ent.Property(x => x.PartsId).HasColumnName("parts_id");
            ent.Property(x => x.Production).HasColumnName("production")
                .HasPrecision(28, 6)
                .HasDefaultValue(0.0);
            ent.Property(x => x.Completed).HasColumnName("completed")
                .HasPrecision(28, 6)
                .HasDefaultValue(0.0);
            ent.Property(x => x.CustomerId).HasColumnName("customer_id");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.ProjectNumber)
                .IsUnique(true)
                .HasDatabaseName("projectnumber_key");
        }
    }
}
