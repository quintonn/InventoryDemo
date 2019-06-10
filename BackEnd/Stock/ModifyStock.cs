using InventorySystem.Models;
using InventorySystem.SiteSpecific;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus.BaseItems;
using WebsiteTemplate.Menus.InputItems;
using WebsiteTemplate.Menus.ViewItems.CoreItems;

namespace InventorySystem.BackEnd.Stock
{
    public abstract class ModifyStock : CoreModify<WarehouseStock>
    {
        public ModifyStock(DataService dataService, bool isNew) : base(dataService, isNew)
        {
        }

        public override string EntityName => "Stock";

        public override EventNumber GetViewNumber()
        {
            return MenuNumber.ViewWarehouses;
        }

        private string WarehouseId { get; set; }
        public override async Task<InitializeResult> Initialize(string data)
        {
            WarehouseId = data;

            return await base.Initialize(data);
        }

        public override List<InputField> InputFields()
        {
            var result = new List<InputField>();

            result.Add(new NumericInput<int>("Quantity", "Quantity", Item?.StockQuantity, null, true));
            if (IsNew)
            {
                result.Add(new DataSourceComboBoxInput<Product>("Product", "Product", x => x.Id, x => x.Name, Item?.Product?.Id, null, null, x => x.Name, true)
                {
                    Mandatory = true
                });
            }
            else
            {
                result.Add(new LabelInput("Product", "Product", Item?.Product?.Name));
            }

            result.Add(new HiddenInput("WarehouseId", WarehouseId));

            return result;
        }

        public override IList<IEvent> PerformModify(bool isNew, string id, ISession session)
        {
            WarehouseStock dbItem;
            if (isNew)
            {
                dbItem = new WarehouseStock();
                var warehouseId = GetValue("WarehouseId");
                var product = GetDataSourceValue<Product>("Product");

                var existingStock = session.QueryOver<WarehouseStock>().Where(x => x.Warehouse.Id == warehouseId && x.Product.Id == product.Id).RowCount();
                if (existingStock > 0)
                {
                    return ErrorMessage("Cannot have more than 1 entry per product per warehouse");
                }
                
                dbItem.Warehouse = session.Get<Warehouse>(warehouseId);
                dbItem.Product = product;
            }
            else
            {
                dbItem = session.Get<WarehouseStock>(id);
            }

            var quantity = GetValue<int>("Quantity");
            
            dbItem.StockQuantity = quantity;

            DataService.SaveOrUpdate(session, dbItem);

            return null;
        }

        public override string GetParameterToPassToView()
        {
            return Item?.Warehouse?.Id;
        }
    }
}