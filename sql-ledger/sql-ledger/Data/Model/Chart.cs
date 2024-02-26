using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Chart
    {
        public int Id { get; set; }
        public string AccNo { get; set; } = null!;
        public string? Description { get; set; }
        public char ChartType { get; set; }
        public char Category { get; set; }
        public string? Link { get; set; }
        public string? GifiAccno { get; set; }
        public bool? Contra { get; set; }
        public bool? Closed { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            var ent = _builder.Entity<Chart>();

            ent.HasNoKey();
            ent.ToTable("chart");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR public_id");
            ent.Property(x => x.AccNo).HasColumnName("accno")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.Description).HasColumnName("description")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.ChartType).HasColumnName("charttype")
                .HasColumnType("char")
                .HasDefaultValue('A');
            ent.Property(x => x.Category).HasColumnName("category")
                .HasColumnType("char");
            ent.Property(x => x.Link).HasColumnName("link")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.GifiAccno).HasColumnName("gifi_accno")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.Contra).HasColumnName("contra")
                .HasDefaultValue(false);
            ent.Property(x => x.Closed).HasColumnName("closed")
                .HasDefaultValue(false);

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.AccNo).HasDatabaseName("chart_accno_key")
                .IsUnique(true);
            ent.HasIndex(x => x.Category).HasDatabaseName("chart_category_key")
                .IsUnique(false);
            ent.HasIndex(x => x.GifiAccno).HasDatabaseName("chart_gifi_accno_key")
                .IsUnique(false);
            ent.HasIndex(x => x.Id).HasDatabaseName("chart_id_key")
                .IsUnique(false);
            ent.HasIndex(x => x.Link).HasDatabaseName("chart_link_key")
                .IsUnique(false);
        }
    }
}
