using Newtonsoft.Json;
using WebsiteTemplate.Menus.BaseItems;

namespace InventorySystem.SiteSpecific
{
    [JsonConverter(typeof(EventNumberConverter))]
    public class MenuNumber : EventNumber
    {
        public MenuNumber(int value)
            : base(value)
        {
        }

        // Use numbers 2000 and above. Numbers below 2000 are for internal menu items.

        public static MenuNumber SampleView = new MenuNumber(2000);
        public static MenuNumber SampleAdd = new MenuNumber(2001);
        public static MenuNumber SampleEdit = new MenuNumber(2002);
        public static MenuNumber SampleDelete = new MenuNumber(2003);

        public static MenuNumber ViewSampleCategories = new MenuNumber(2010);

        public static MenuNumber AdvancedView = new MenuNumber(2020);
        public static MenuNumber AdvancedAdd = new MenuNumber(2021);
        public static MenuNumber AdvancedEdit = new MenuNumber(2022);
        public static MenuNumber AdvancedDelete = new MenuNumber(2023);
        public static MenuNumber AdvancedDetails = new MenuNumber(2024);

        public static MenuNumber SampleBackgroundProcess = new MenuNumber(2030);

        public static MenuNumber Companies = new MenuNumber(2040);

        public static MenuNumber ProuctTypes = new MenuNumber(2050);

        public static MenuNumber ViewProducts = new MenuNumber(2060);
        public static MenuNumber AddProduct = new MenuNumber(2061);
        public static MenuNumber EditProduct = new MenuNumber(2062);
        public static MenuNumber DeleteProduct = new MenuNumber(2063);

        public static MenuNumber ViewWarehouses = new MenuNumber(2070);
        public static MenuNumber AddWarehouse = new MenuNumber(2071);
        public static MenuNumber EditWarehouse = new MenuNumber(2072);
        public static MenuNumber DeleteWarehouse = new MenuNumber(2073);

        public static MenuNumber ViewStocks = new MenuNumber(2080);
        public static MenuNumber AddStock = new MenuNumber(2081);
        public static MenuNumber EditStock = new MenuNumber(2082);
        public static MenuNumber DeleteStock = new MenuNumber(2083);
    }
}