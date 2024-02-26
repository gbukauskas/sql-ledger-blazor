using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Acc_trans
    {
        public int? TransId { get; set; }
        public int? ChartId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? TransDate { get; set; }
        string? Source { get; set; }
        public bool? Approved { get; set; }
        public bool? FxTransaction { get; set; }
        public int? ProjectId { get; set; }
        public string? Memo { get; set; }
        public int? Id { get; set; }
        public DateTime? Cleared { get; set; }
        public int? VrId { get; set; }

        public byte[]? RowVersion { get; set; } = null;


        public static void Configure(ModelBuilder _builder)
        {

            var ent = _builder.Entity<Acc_trans>();
            
            ent.HasNoKey();
            ent.ToTable("acc_trans");

            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.ChartId).HasColumnName("chart_id");
            ent.Property(x => x.Amount).HasColumnName("amount")
                .HasPrecision(28, 6);
            ent.Property(x => x.TransDate).HasColumnName("transdate");
            ent.Property(x => x.Source).HasColumnName("source")
                .HasColumnType("nvarchar(4000)");
            ent.Property(x => x.Approved).HasColumnName("approved");
            ent.Property(x => x.FxTransaction).HasColumnName("fx_transaction")
                .HasDefaultValue(false);
            ent.Property(x => x.ProjectId).HasColumnName("project_id");
            ent.Property(x => x.Memo).HasColumnName("memo")
                .HasColumnType("nvarchar(MAX)");
            ent.Property(x => x.Id).HasColumnName("id");
            ent.Property(x => x.Cleared).HasColumnName("cleared");
            ent.Property(x => x.VrId).HasColumnName("vr_id");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.ChartId).HasDatabaseName("acc_trans_chart_id_key");
            ent.HasIndex(x => x.Source).HasDatabaseName("acc_trans_source_key");
            ent.HasIndex(x => x.TransId).HasDatabaseName("acc_trans_trans_id_key");
            ent.HasIndex(x => x.TransDate).HasDatabaseName("acc_trans_transdate_key");
        }
    }
}
