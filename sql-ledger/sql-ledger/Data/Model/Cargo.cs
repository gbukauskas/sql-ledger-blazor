using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Cargo
    {
        public int Id { get; set; }
        public int? TransId { get; set; }
        public string? Package { get; set; }
        public decimal? NetWeight { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? Volume { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Cargo>();

            ent.HasKey(x => new { x.Id, x.TransId } ).HasName("cargo_id_key");
            ent.ToTable("cargo");

            ent.Property(x => x.Id).HasColumnName("id");
            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.Package).HasColumnName("package")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.NetWeight).HasColumnName("netweight")
                .HasPrecision(28, 6);
            ent.Property(x => x.GrossWeight).HasColumnName("grossweight")
                .HasPrecision(28, 6);
            ent.Property(x => x.Volume).HasColumnName("volume")
                .HasPrecision(28, 6);

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
