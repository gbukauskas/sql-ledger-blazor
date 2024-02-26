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
}
