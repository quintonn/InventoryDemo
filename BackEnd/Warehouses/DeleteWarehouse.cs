using InventorySystem.Models;
using InventorySystem.SiteSpecific;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus.BaseItems;
using WebsiteTemplate.Menus.ViewItems.CoreItems;

namespace InventorySystem.BackEnd.Warehouses
{
    public class DeleteWarehouse : CoreDeleteAction<Warehouse>
    {
        public DeleteWarehouse(DataService dataService) : base(dataService)
        {
        }

        public override string EntityName => "Warehouse";

        public override EventNumber ViewNumber => MenuNumber.ViewWarehouses;

        public override EventNumber GetId()
        {
            return MenuNumber.DeleteWarehouse;
        }

        public override void DeleteOtherItems(ISession session, Warehouse mainItem)
        {
            session.Query<WarehouseStock>().Where(x => x.Warehouse.Id == mainItem.Id).Delete();
        }
    }
}