using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Recurring
    {
        public int Id { get; set; }
        public string? Reference { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? NextDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short? Repeat { get; set; }
        public string? Unit { get; set; }
        public int? HowMany { get; set; }
        public bool Payment { get; set; }
        public string? Description { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Recurring>();

            ent.HasNoKey();
            ent.ToTable("recurring");

            ent.Property(x => x.Id).HasColumnName("id");
            ent.Property(x => x.Reference).HasColumnName("reference")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.StartDate).HasColumnName("startdate");
            ent.Property(x => x.NextDate).HasColumnName("nextdate");
            ent.Property(x => x.EndDate).HasColumnName("enddate");
            ent.Property(x => x.Repeat).HasColumnName("repeat");
            ent.Property(x => x.Unit).HasColumnName("unit")
                .HasColumnType("nvarchar(5)")
                .HasMaxLength(5);
            ent.Property(x => x.HowMany).HasColumnName("howmany");
            ent.Property(x => x.Payment).HasColumnName("payment")
                .HasDefaultValue(false);
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
