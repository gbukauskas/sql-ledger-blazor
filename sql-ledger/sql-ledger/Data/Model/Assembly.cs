using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Assembly
    {
        public int Id { get; set; }
        public int? PartsId { get; set; }
        decimal? Qty { get; set; }
        public bool? Bom { get; set; }
        public bool? Adj { get; set; }
        public int? Aid { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            _builder.HasSequence<int>("assembly_id")
                .StartsAt(1)
                .IncrementsBy(1);
            
            var ent = _builder.Entity<Assembly>();

            ent.HasKey(x => x.Id).HasName("assembly_id_key");
            ent.ToTable("assembly");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR assembly_id");
            ent.Property(x => x.PartsId).HasColumnName("parts_id");
            ent.Property(x => x.Qty).HasColumnName("qty")
                .HasPrecision(28, 6);
            ent.Property(x => x.Bom).HasColumnName("bom");
            ent.Property(x => x.Adj).HasColumnName("adj");
            ent.Property(x => x.Aid).HasColumnName("aid");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

        }
    }
}
