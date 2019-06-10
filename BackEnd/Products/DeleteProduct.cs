using InventorySystem.Models;
using InventorySystem.SiteSpecific;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus.BaseItems;
using WebsiteTemplate.Menus.ViewItems.CoreItems;

namespace InventorySystem.BackEnd.Products
{
    public class DeleteProduct : CoreDeleteAction<Product>
    {
        public DeleteProduct(DataService dataService) : base(dataService)
        {
        }

        public override string EntityName => "Product";

        public override EventNumber ViewNumber => MenuNumber.ViewProducts;

        public override EventNumber GetId()
        {
            return MenuNumber.DeleteProduct;
        }
    }
}