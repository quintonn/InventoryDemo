using InventorySystem.Models;
using InventorySystem.SiteSpecific;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using WebsiteTemplate.Menus.BaseItems;
using WebsiteTemplate.Menus.BasicCrudItems;

namespace InventorySystem.BackEnd.Companies
{
    public class CompaniesMenuItem : BasicCrudMenuItem<Company>
    {
        public override bool AllowInMenu => true;

        public override string GetBaseItemName()
        {
            return "Company";
        }

        public override EventNumber GetBaseMenuId()
        {
            return MenuNumber.Companies;
        }

        public override Dictionary<string, string> GetColumnsToShowInView()
        {
            return new Dictionary<string, string>()
            {
                { "Name", "Name" }
            };
        }

        public override Dictionary<string, string> GetInputProperties()
        {
            return new Dictionary<string, string>()
            {
                { "Name", "Name" }
            };
        }

        public override void OnDelete(ISession session, Company item)
        {
            var warehouses = session.QueryOver<Warehouse>().Where(x => x.Company.Id == item.Id).List().ToList();
            foreach (var warehouse in warehouses)
            {
                session.Query<WarehouseStock>().Where(x => x.Warehouse.Id == warehouse.Id).Delete();
                session.Delete(warehouse);
            }
            
            base.OnDelete(session, item);
        }
    }
}