using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class JcItem
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public int? PartsId { get; set; }
        public string? Description { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Allocated { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? FxSellPrice { get; set; }
        public string? SerialNumber { get; set; }
        public DateTime? CheckedIn { get; set; }
        public DateTime? CheckedOut { get; set; }
        public int? EmployeeId { get; set; }
        public string? Notes { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            _builder.HasSequence<int>("jcitems_id")
                .StartsAt(1)
                .IncrementsBy(1);

            var ent = _builder.Entity<JcItem>();

            ent.HasKey(e => e.Id).HasName("jcitems_id_key");
            ent.ToTable("jcitems");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR jcitems_id");
            ent.Property(x => x.ProjectId).HasColumnName("project_id");
            ent.Property(x => x.PartsId).HasColumnName("parts_id");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Qty).HasColumnName("qty")
                .HasPrecision(28, 6);
            ent.Property(x => x.Allocated).HasColumnName("allocated")
                .HasPrecision(28, 6);
            ent.Property(x => x.SellPrice).HasColumnName("sellprice")
                .HasPrecision(28, 6);
            ent.Property(x => x.FxSellPrice).HasColumnName("fxsellprice")
                .HasPrecision(28, 6);
            ent.Property(x => x.SerialNumber).HasColumnName("serialnumber")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.CheckedIn).HasColumnName("checkedin");
            ent.Property(x => x.CheckedOut).HasColumnName("checkedout");
            ent.Property(x => x.EmployeeId).HasColumnName("employee_id");
            ent.Property(x => x.Notes).HasColumnName("notes")
                .HasColumnType("nvarchar(MAX)");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
