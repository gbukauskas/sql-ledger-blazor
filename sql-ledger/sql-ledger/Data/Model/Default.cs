using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Default
    {
        public required string FldName { get; set; }
        public string? FldValue { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Default>();

            ent.HasNoKey();
            ent.ToTable("defaults");

            ent.Property(x => x.FldName).HasColumnName("fldname")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.FldValue).HasColumnName("fldvalue")
                .HasColumnType("nvarchar(MAX)");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
