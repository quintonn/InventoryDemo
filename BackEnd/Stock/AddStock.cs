using InventorySystem.SiteSpecific;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus.BaseItems;

namespace InventorySystem.BackEnd.Stock
{
    public class AddStock : ModifyStock
    {
        public AddStock(DataService dataService) : base(dataService, true)
        {
        }

        public override EventNumber GetId()
        {
            return MenuNumber.AddStock;
        }
    }
}