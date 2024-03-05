using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class PayTrans
    {
        public int? TransId { get; set; }
        public int? Id { get; set; }
        public int? GlId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Amount { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<PayTrans>();

            ent.HasNoKey();
            ent.ToTable("pay_trans");

            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.Id).HasColumnName("id");
            ent.Property(x => x.GlId).HasColumnName("glid");
            ent.Property(x => x.Qty).HasColumnName("qty")
                .HasPrecision(28, 6);
            ent.Property(x => x.Amount).HasColumnName("amount")
                .HasPrecision(28, 6);

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
