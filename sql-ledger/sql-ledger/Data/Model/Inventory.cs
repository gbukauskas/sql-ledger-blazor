using Microsoft.EntityFrameworkCore;

namespace sql_ledger.Data.Model
{
    public class Inventory
    {
        public int Id { get; set; }
        public int? WarehouseId { get; set; }
        public int? PartsId { get; set; }
        public int? TransId { get; set; }
        public int? OrderItemsId { get; set; }
        public decimal? Qty { get; set; }
        public DateTime? ShippingDate { get; set; }
        public int? EmployeeId { get; set; }
        public byte[]? RowVersion { get; set; } = null;

        public static void Configure(ModelBuilder _builder)
        {
            _builder.HasSequence<int>("inventory_id")
                .StartsAt(1)
                .IncrementsBy(1);

            var ent = _builder.Entity<Inventory>();

            ent.HasKey(g => g.Id).HasName("inventory_id_key");
            ent.ToTable("inventory");

            ent.Property(x => x.Id).HasColumnName("id")
                .HasDefaultValueSql<int>("NEXT VALUE FOR inventory_id");
            ent.Property(x => x.WarehouseId).HasColumnName("warehouse_id");
            ent.Property(x => x.PartsId).HasColumnName("parts_id");
            ent.Property(x => x.TransId).HasColumnName("trans_id");
            ent.Property(x => x.OrderItemsId).HasColumnName("orderitems_id");
            ent.Property(x => x.Qty).HasColumnName("qty")
                .HasPrecision(28, 6);
            ent.Property(x => x.ShippingDate).HasColumnName("shippingdate");
            ent.Property(x => x.EmployeeId).HasColumnName("employee_id");

            ent.Property(x => x.RowVersion).HasColumnName("row_version")
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            ent.HasIndex(x => x.PartsId).HasDatabaseName("inventory_parts_id_key");
        }
    }
}
