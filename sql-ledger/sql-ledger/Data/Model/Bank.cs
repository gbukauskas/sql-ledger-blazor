using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Bank
    {
        public int? Id { get; set; }
        public string? Name { get; set; }  
        public string? Iban { get; set; }
        public string? Bic {  get; set; }
        public int AddressId { get; set; }
        public string? Dcn { get; set; }
        public string? Rvc { get; set; }
        public string? MemberNumber { get; set; }
        public string? ClearingNumber { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Bank>();

            ent.HasNoKey();
            ent.ToTable("bank");

            ent.Property(x => x.Id).HasColumnName("id");
            ent.Property(x => x.Name).HasColumnName("name")
                .HasColumnType("nvarchar(64)");
            ent.Property(x => x.Iban).HasColumnName("iban")
                .HasColumnType("nvarchar(34)");
            ent.Property(x => x.Bic).HasColumnName("bic")
                .HasColumnType("nvarchar(11)");
            ent.Property(x => x.AddressId).HasColumnName("address_id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR address_id");
            ent.Property(x => x.Dcn).HasColumnName("dcn")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Rvc).HasColumnName("rvc")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.MemberNumber).HasColumnName("membernumber")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.ClearingNumber).HasColumnName("clearingnumber")
                .HasColumnType("nvarchar(MAX)");
            
            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
