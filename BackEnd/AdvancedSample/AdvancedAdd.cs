using InventorySystem.SiteSpecific;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus.BaseItems;

namespace InventorySystem.BackEnd.AdvancedSample
{
    public class AdvancedAdd : AdvancedModify
    {
        public AdvancedAdd(DataService dataService)
            : base(dataService, true)
        {
        }

        public override EventNumber GetId()
        {
            return MenuNumber.AdvancedAdd;
        }
    }
}