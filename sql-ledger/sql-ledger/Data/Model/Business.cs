using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Business
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public float? Discount { get; set; }
        public int? Rn { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Business>();

            ent.HasNoKey();
            ent.ToTable("business");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id"); ;
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Discount).HasColumnName("discount");
            ent.Property(x => x.Rn).HasColumnName("rn");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

        }
    }
}
