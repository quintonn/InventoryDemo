using InventorySystem.Models;
using InventorySystem.SiteSpecific;
using System.Collections.Generic;
using WebsiteTemplate.Menus.BaseItems;
using WebsiteTemplate.Menus.BasicCrudItems;

namespace InventorySystem.BackEnd.Products
{
    public class ProductTypeMenuItem : BasicCrudMenuItem<ProductType>
    {
        public override bool AllowInMenu => true;

        public override string GetBaseItemName()
        {
            return "Product Type";
        }

        public override EventNumber GetBaseMenuId()
        {
            return MenuNumber.ProuctTypes;
        }

        public override Dictionary<string, string> GetColumnsToShowInView()
        {
            return new Dictionary<string, string>()
            {
                { "Name", "Name" },
                { "Description", "Description" }
            };
        }

        public override Dictionary<string, string> GetInputProperties()
        {
            return new Dictionary<string, string>()
            {
                { "Name", "Name" },
                { "Description", "Description" }
            };
        }
    }
}