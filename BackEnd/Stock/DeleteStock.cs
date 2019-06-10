using InventorySystem.Models;
using InventorySystem.SiteSpecific;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus.BaseItems;
using WebsiteTemplate.Menus.ViewItems.CoreItems;

namespace InventorySystem.BackEnd.Stock
{
    public class DeleteStock : CoreDeleteAction<WarehouseStock>
    {
        public DeleteStock(DataService dataService) : base(dataService)
        {
        }

        public override string EntityName => "Stock";

        public override EventNumber ViewNumber => MenuNumber.ViewWarehouses;

        public override EventNumber GetId()
        {
            return MenuNumber.DeleteStock;
        }
    }
}