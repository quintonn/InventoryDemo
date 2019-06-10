using QBic.Core.Models;

namespace InventorySystem.Models
{
    public class WarehouseStock : DynamicClass
    {
        public virtual Warehouse Warehouse { get; set; }

        public virtual Product Product { get; set; }

        public virtual int StockQuantity { get; set; }
    }
}