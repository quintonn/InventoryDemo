using InventorySystem.SiteSpecific;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus.BaseItems;

namespace InventorySystem.BackEnd.Products
{
    public class EditProduct : ModifyProduct
    {
        public EditProduct(DataService dataService) : base(dataService, false)
        {
        }

        public override EventNumber GetId()
        {
            return MenuNumber.EditProduct;
        }
    }
}