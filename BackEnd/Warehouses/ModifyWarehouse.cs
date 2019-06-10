using BasicAuthentication.ControllerHelpers;
using InventorySystem.Models;
using InventorySystem.SiteSpecific;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Data;
using WebsiteTemplate.Menus.BaseItems;
using WebsiteTemplate.Menus.InputItems;
using WebsiteTemplate.Menus.ViewItems.CoreItems;
using WebsiteTemplate.Models;

namespace InventorySystem.BackEnd.Warehouses
{
    public abstract class ModifyWarehouse : CoreModify<Warehouse>
    {
        private UserContext UserContext { get; set; }
        public ModifyWarehouse(DataService dataService, bool isNew, UserContext userContext)
        : base(dataService, isNew)
        {
            UserContext = userContext;
        }

        public override string EntityName => "Warehouse";

        public override EventNumber GetViewNumber()
        {
            return MenuNumber.ViewWarehouses;
        }

        public override List<InputField> InputFields()
        {
            var result = new List<InputField>();

            result.Add(new StringInput("Name", "Name", Item?.Name, null, true));
            result.Add(new StringInput("Address", "Address", Item?.Address, null, true));

            return result;
        }

        public override IList<IEvent> PerformModify(bool isNew, string id, ISession session)
        {
            var name = GetValue("Name");
            var address = GetValue("Address");

            var currentUser = Methods.GetLoggedInUserAsync(UserContext).Result as User;
            var profile = session.QueryOver<UserProfile>().Where(x => x.User.Id == currentUser.Id).SingleOrDefault();

            Warehouse dbItem;

            if (isNew)
            {
                dbItem = new Warehouse();
                dbItem.Company = profile.Company;
            }
            else
            {
                dbItem = session.Get<Warehouse>(id);
            }

            dbItem.Name = name;
            dbItem.Address = address;

            DataService.SaveOrUpdate(session, dbItem);

            return null;
        }
    }
}