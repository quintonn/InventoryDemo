using InventorySystem.SiteSpecific;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus.BaseItems;

namespace InventorySystem.BackEnd.Products
{
    public class AddProduct : ModifyProduct
    {
        public AddProduct(DataService dataService) : base(dataService, true)
        {
        }

        public override EventNumber GetId()
        {
            return MenuNumber.AddProduct;
        }
    }
}