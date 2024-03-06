using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class PayRate
    {
        public int? TransId { get; set; }
        public int? Id { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Above { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<PayRate>();

            ent.HasNoKey();
            ent.ToTable("payrate");

            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.Id).HasColumnName("id");
            ent.Property(x => x.Rate).HasColumnName("rate")
                .HasPrecision(28, 6);
            ent.Property(x => x.Above).HasColumnName("above")
                .HasPrecision(28, 6);

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
