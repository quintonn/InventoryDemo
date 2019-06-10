using QBic.Core.Models;

namespace InventorySystem.Models
{
    public class Product : DynamicClass
    {
        public virtual string Name { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}