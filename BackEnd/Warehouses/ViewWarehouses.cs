using BasicAuthentication.ControllerHelpers;
using InventorySystem.Models;
using InventorySystem.SiteSpecific;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Data;
using WebsiteTemplate.Menus;
using WebsiteTemplate.Menus.BaseItems;
using WebsiteTemplate.Menus.ViewItems;
using WebsiteTemplate.Menus.ViewItems.CoreItems;
using WebsiteTemplate.Models;

namespace InventorySystem.BackEnd.Warehouses
{
    public class ViewWarehouses : CoreView<Warehouse>
    {
        private UserContext UserContext { get; set; }
        public ViewWarehouses(DataService dataService, UserContext userContext) 
            : base(dataService)
        {
            UserContext = userContext;
        }

        public override bool AllowInMenu => true;

        public override string Description => "View Warehouses";

        public override void ConfigureColumns(ColumnConfiguration columnConfig)
        {
            columnConfig.AddStringColumn("Name", "Name");
            columnConfig.AddStringColumn("Address", "Address");
            columnConfig.AddStringColumn("Company", "Company.Name");

            columnConfig.AddLinkColumn("", "Id", "Edit", MenuNumber.EditWarehouse);
            columnConfig.AddLinkColumn("", "Id", "Stock", MenuNumber.ViewStocks);
            columnConfig.AddButtonColumn("", "Id", "X", new UserConfirmation("Delete warehouse?", MenuNumber.DeleteWarehouse));
        }

        public override IQueryOver<Warehouse> CreateQuery(ISession session, GetDataSettings settings, Expression<Func<Warehouse, bool>> additionalCriteria = null)
        {
            var currentUser = Methods.GetLoggedInUserAsync(UserContext).Result as User;
            var profile = session.QueryOver<UserProfile>().Where(x => x.User.Id == currentUser.Id).SingleOrDefault();

            var companyId = profile?.Company?.Id;

            return base.CreateQuery(session, settings, x => x.Company.Id == companyId);
        }

        public override List<Expression<Func<Warehouse, object>>> GetFilterItems()
        {
            return new List<Expression<Func<Warehouse, object>>>()
            {
                x => x.Name,
                x => x.Address
            };
        }

        public override EventNumber GetId()
        {
            return MenuNumber.ViewWarehouses;
        }

        public override IList<MenuItem> GetViewMenu(Dictionary<string, string> dataForMenu)
        {
            return new List<MenuItem>()
            {
                new MenuItem("Add", MenuNumber.AddWarehouse)
            };
        }
    }
}