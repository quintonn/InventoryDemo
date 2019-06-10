using InventorySystem.Models;
using InventorySystem.SiteSpecific;
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

namespace InventorySystem.BackEnd.Products
{
    public class ViewProduct : CoreView<Product>
    {
        public ViewProduct(DataService dataService) : base(dataService)
        {
        }

        public override bool AllowInMenu => true;

        public override string Description => "View Products";

        public override void ConfigureColumns(ColumnConfiguration columnConfig)
        {
            columnConfig.AddStringColumn("Name", "Name");
            columnConfig.AddStringColumn("Product Type", "ProductType.Name");

            columnConfig.AddLinkColumn("", "Id", "Edit", MenuNumber.EditProduct);
            columnConfig.AddButtonColumn("", "Id", "X", new UserConfirmation("Delete product?", MenuNumber.DeleteProduct));
        }

        public override List<Expression<Func<Product, object>>> GetFilterItems()
        {
            return new List<Expression<Func<Product, object>>>()
            {
                x => x.Name
            };
        }

        public override EventNumber GetId()
        {
            return MenuNumber.ViewProducts;
        }

        public override IList<MenuItem> GetViewMenu(Dictionary<string, string> dataForMenu)
        {
            return new List<MenuItem>()
            {
                new MenuItem("Add", MenuNumber.AddProduct)
            };
        }
    }
}