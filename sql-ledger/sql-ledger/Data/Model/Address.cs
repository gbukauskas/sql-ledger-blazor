using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Address
    {
        public int Id { get; set; }
        public int? TransId { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode { get; set; }
        public string? Country { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            _builder.HasSequence<int>("address_id")
                .StartsAt(1)
                .IncrementsBy(1);

            var ent = _builder.Entity<Address>();

            ent.HasKey(x => x.Id).HasName("address_pkey");
            ent.ToTable("address");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR address_id");
            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.Address1).HasColumnName("address1")
                .HasColumnType("nvarchar(32)")
                .HasMaxLength(32);
            ent.Property(x => x.Address2).HasColumnName("address2")
                .HasColumnType("nvarchar(32)")
                .HasMaxLength(32);
            ent.Property(x => x.City).HasColumnName("city")
                .HasColumnType("nvarchar(32)")
                .HasMaxLength(32);
            ent.Property(x => x.State).HasColumnName("state")
                .HasColumnType("nvarchar(32)")
                .HasMaxLength(32);
            ent.Property(x => x.Zipcode).HasColumnName("zipcode")
                .HasColumnType("nvarchar(10)")
                .HasMaxLength(10);
            ent.Property(x => x.Country).HasColumnName("country")
                .HasColumnType("nvarchar(32)")
                .HasMaxLength(32);
            
            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

        }
    }
}
