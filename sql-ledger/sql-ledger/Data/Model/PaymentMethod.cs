using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal? Fee { get; set; }
        public short? Rn { get; set; }
        public double? RoundChange { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<PaymentMethod>();

            ent.HasKey(x => x.Id).HasName("paymentmethod_pkey");
            ent.ToTable("paymentmethod");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Fee).HasColumnName("fee")
                .HasPrecision(28, 6);
            ent.Property(x => x.Rn).HasColumnName("rn");
            ent.Property(x => x.RoundChange).HasColumnName("roundchange")
                .HasColumnType("float");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}