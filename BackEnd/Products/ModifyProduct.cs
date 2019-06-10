using InventorySystem.Models;
using InventorySystem.SiteSpecific;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus.BaseItems;
using WebsiteTemplate.Menus.InputItems;
using WebsiteTemplate.Menus.ViewItems.CoreItems;

namespace InventorySystem.BackEnd.Products
{
    public abstract class ModifyProduct : CoreModify<Product>
    {
        public  ModifyProduct(DataService dataService, bool isNew) : base(dataService, isNew)
        {
        }

        public override string EntityName => "Product";

        public override EventNumber GetViewNumber()
        {
            return MenuNumber.ViewProducts;
        }

        public override List<InputField> InputFields()
        {
            var result = new List<InputField>();

            result.Add(new StringInput("Name", "Name", Item?.Name, null, true));
            result.Add(new DataSourceComboBoxInput<ProductType>("ProductType", "Product Type", x => x.Id, x => x.Name, Item?.ProductType?.Id, null, null, x => x.Name, true, false)
            {
                Mandatory = true
            });

            return result;
        }

        public override IList<IEvent> PerformModify(bool isNew, string id, ISession session)
        {
            Product dbItem;

            var name = GetValue("Name");
            var productType = GetDataSourceValue<ProductType>("ProductType");

            if (isNew)
            {
                dbItem = new Product();
            }
            else
            {
                dbItem = session.Get<Product>(id);
            }

            dbItem.Name = name;
            dbItem.ProductType = productType;

            DataService.SaveOrUpdate(session, dbItem);

            return null;
        }
    }
}