using QBic.Core.Models;

namespace InventorySystem.Models
{
    public class ProductType : DynamicClass
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }
    }
}