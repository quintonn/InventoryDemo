using InventorySystem.SiteSpecific;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus.BaseItems;

namespace InventorySystem.MenuItems.Sample
{
    public class TestAdd : TestModify
    {
        public TestAdd(DataService dataService)
            : base(dataService, true)
        {
        }

        public override EventNumber GetId()
        {
            return MenuNumber.SampleAdd;
        }
    }
}