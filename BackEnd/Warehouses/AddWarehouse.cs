using InventorySystem.SiteSpecific;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Data;
using WebsiteTemplate.Menus.BaseItems;

namespace InventorySystem.BackEnd.Warehouses
{
    public class AddWarehouse : ModifyWarehouse
    {
        public AddWarehouse(DataService dataService, UserContext userContext)
            : base(dataService, true, userContext)
        {
        }

        public override EventNumber GetId()
        {
            return MenuNumber.AddWarehouse;
        }
    }
}