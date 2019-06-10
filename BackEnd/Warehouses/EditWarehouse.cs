using InventorySystem.SiteSpecific;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Data;
using WebsiteTemplate.Menus.BaseItems;

namespace InventorySystem.BackEnd.Warehouses
{
    public class EditWarehouse : ModifyWarehouse
    {
        public EditWarehouse(DataService dataService, UserContext userContext)
            : base(dataService, false, userContext)
        {
        }

        public override EventNumber GetId()
        {
            return MenuNumber.EditWarehouse;
        }
    }
}