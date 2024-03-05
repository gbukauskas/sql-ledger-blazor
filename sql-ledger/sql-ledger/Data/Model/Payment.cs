using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public int TransId { get; set; }
        public double? ExchangeRate { get; set; }
        public int? PaymentMethodId { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Payment>();

            ent.HasNoKey();
            ent.ToTable("payment");

            ent.Property(x => x.Id).HasColumnName("id");
            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.ExchangeRate).HasColumnName("exchangerate")
                .HasColumnType("float")
                .HasDefaultValue(1.0);
            ent.Property(x => x.PaymentMethodId).HasColumnName("paymentmethod_id");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
