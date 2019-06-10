using InventorySystem.SiteSpecific;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus.BaseItems;

namespace InventorySystem.BackEnd.Stock
{
    public class EditStock : ModifyStock
    {
        public EditStock(DataService dataService) : base(dataService, false)
        {
        }

        public override EventNumber GetId()
        {
            return MenuNumber.EditStock;
        }
    }
}