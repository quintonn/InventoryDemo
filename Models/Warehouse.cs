using QBic.Core.Models;

namespace InventorySystem.Models
{
    public class Warehouse : DynamicClass
    {
        public virtual string Name { get; set; }

        public virtual string Address { get; set; }

        public virtual Company Company { get; set; }
    }
}