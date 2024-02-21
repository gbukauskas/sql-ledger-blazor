using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class AcsRole
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Acs { get; set; }
        public short? Rn { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<AcsRole>();

            ent.HasKey(x => x.Id).HasName("acsrole_pkey");
            ent.ToTable("acsrole");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Acs).HasColumnName("acs");
            ent.Property(x => x.Rn).HasColumnName("rn");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

        }
    }

}
