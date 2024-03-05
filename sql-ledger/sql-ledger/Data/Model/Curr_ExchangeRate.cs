using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Currency
    {
        public short? Rn { get; set; }
        public string? Curr { get; set; }
        public short? Prec { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Currency>();

            ent.HasKey(x => x.Curr).HasName("curr_pkey");
            ent.ToTable("curr");

            ent.Property(x => x.Rn).HasColumnName("rn");
            ent.Property(x => x.Curr).HasColumnName("curr")
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
        public string? Curr { get; set; }
        public DateTime? TransDate { get; set; }
        public double? ExchangeRateValue { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public Currency CurrencyValue { get; set; } = null!;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<ExchangeRate>();

            ent.HasKey(e => new {e.Curr, e.TransDate}).HasName("exchangerate_ct_key");
            ent.ToTable("exchangerate");

            ent.Property(x => x.Curr).HasColumnName("curr")
                .HasColumnType("char(3)")
                .HasMaxLength(3);
            ent.Property(x => x.TransDate).HasColumnName("transdate");
            ent.Property(x => x.ExchangeRateValue).HasColumnName("exchangerate")
                .HasColumnType("float");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();


            ent.HasOne(e => e.CurrencyValue)
                .WithMany()
                .HasForeignKey(e => e.Curr)
                .HasConstraintName("exchangerate_curr_id_fkey")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
