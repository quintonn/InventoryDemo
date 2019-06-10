using InventorySystem.SiteSpecific;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus.BaseItems;

namespace InventorySystem.MenuItems.Sample
{
    public class TestEdit : TestModify
    {
        public TestEdit(DataService dataService)
            : base(dataService, false)
        {
        }

        public override EventNumber GetId()
        {
            return MenuNumber.SampleEdit;
        }
    }
}