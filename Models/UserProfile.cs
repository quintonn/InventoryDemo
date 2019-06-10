using QBic.Core.Models;
using WebsiteTemplate.Models;

namespace InventorySystem.Models
{
    public class UserProfile : DynamicClass
    {
        public virtual User User { get; set; }

        public virtual Company Company { get; set; }
    }
}