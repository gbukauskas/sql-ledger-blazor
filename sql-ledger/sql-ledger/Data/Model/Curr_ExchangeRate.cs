using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Curr
    {
        public short? Rn { get; set; }
        public string? Currency { get; set; }
        public short? Prec { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Curr>();

            ent.HasKey(x => x.Currency).HasName("curr_pkey");
            ent.ToTable("curr");

            ent.Property(x => x.Rn).HasColumnName("rn");
            ent.Property(x => x.Currency).HasColumnName("curr")
                .HasColumnType("char(3)")
                .HasMaxLength(3);
            ent.Property(x => x.Prec).HasColumnName("prec");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }

    public class ExchangeRate
    {
        public string? Currency { get; set; }
        public DateTime? TransDate { get; set; }
        public double? ExchangeRateValue { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public Curr Curr { get; set; } = null!;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<ExchangeRate>();

            ent.HasKey(e => new {e.Currency, e.TransDate}).HasName("exchangerate_ct_key");
            ent.ToTable("exchangerate");

            ent.Property(x => x.Currency).HasColumnName("curr")
                .HasColumnType("char(3)")
                .HasMaxLength(3);
            ent.Property(x => x.TransDate).HasColumnName("transdate");
            ent.Property(x => x.ExchangeRateValue).HasColumnName("exchangerate")
                .HasColumnType("float");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();


            ent.HasOne(e => e.Curr)
                .WithMany()
                .HasForeignKey(e => e.Currency)
                .HasConstraintName("exchangerate_curr_id_fkey")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
