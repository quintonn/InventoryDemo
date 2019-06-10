using InventorySystem.Models;
using InventorySystem.SiteSpecific;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus;
using WebsiteTemplate.Menus.BaseItems;
using WebsiteTemplate.Menus.ViewItems;
using WebsiteTemplate.Menus.ViewItems.CoreItems;

namespace InventorySystem.BackEnd.Stock
{
    public class ViewStock : CoreView<WarehouseStock>
    {
        public ViewStock(DataService dataService) : base(dataService)
        {
        }

        private string WarehouseId { get; set; }

        public override string Description => "View Warehouse Stock";

        public override void ConfigureColumns(ColumnConfiguration columnConfig)
        {
            columnConfig.AddStringColumn("Warehouse", "Warehouse.Name");
            columnConfig.AddStringColumn("Product", "Product.Name");
            columnConfig.AddStringColumn("Quantity", "StockQuantity");

            columnConfig.AddLinkColumn("", "Id", "Edit", MenuNumber.EditStock);
            columnConfig.AddButtonColumn("", "Id", "X", new UserConfirmation("Delete warehouse stock?", MenuNumber.DeleteStock));
        }

        public override List<Expression<Func<WarehouseStock, object>>> GetFilterItems()
        {
            return new List<Expression<Func<WarehouseStock, object>>>()
            {

            };
        }

        public override IQueryOver<WarehouseStock> CreateQuery(ISession session, GetDataSettings settings, Expression<Func<WarehouseStock, bool>> additionalCriteria = null)
        {
            var warehouseId = this.GetParameter("Id", "WarehouseId", settings);
            WarehouseId = warehouseId;
            return base.CreateQuery(session, settings, x => x.Warehouse.Id == warehouseId);
        }

        public override EventNumber GetId()
        {
            return MenuNumber.ViewStocks;
        }

        public override Dictionary<string, string> GetViewParameters(GetDataSettings settings)
        {
            var warehouseId = this.GetParameter("Id", "WarehouseId", settings);

            return new Dictionary<string, string>()
            {
                { "warehouseId", warehouseId }
            };
        }

        public override IList<MenuItem> GetViewMenu(Dictionary<string, string> dataForMenu)
        {
            return new List<MenuItem>()
            {
                new MenuItem("Back", MenuNumber.ViewWarehouses),
                new MenuItem("Add", MenuNumber.AddStock, dataForMenu["warehouseId"])
            };
        }
    }
}