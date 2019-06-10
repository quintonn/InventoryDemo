using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using InventorySystem.Models;
using NHibernate;
using NHibernate.Linq;
using WebsiteTemplate.Backend.Processing.InputProcessing;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Backend.Users;
using WebsiteTemplate.Menus.InputItems;
using WebsiteTemplate.Models;

namespace InventorySystem.SiteSpecific
{
    public class InventorySystemUserInjector : UserInjector
    {
        public InventorySystemUserInjector(DataService dataService) : base(dataService)
        {
        }

        public override ProcessingResult DeleteItem(ISession session, string itemId)
        {
            session.Query<UserProfile>().Where(x => x.User.Id == itemId).Delete();
            return new ProcessingResult(true);
        }

        public override IList<InputField> GetInputFields(User user)
        {
            var result = new List<InputField>();

            using (var session = DataService.OpenSession())
            {
                var userProfile = session.QueryOver<UserProfile>().Where(x => x.User.Id == user.Id).SingleOrDefault();
                result.Add(new DataSourceComboBoxInput<Company>("Company", "Company", x => x.Id, x => x.Name, userProfile?.Company?.Id, null, null, x => x.Name, true)
                {
                    Mandatory = true
                });
            }

            return result;
        }

        public override async Task<ProcessingResult> SaveOrUpdate(ISession session, string username)
        {
            User user = null;
            var userProfile = session.QueryOver<UserProfile>()
                                     .JoinAlias(x => x.User, () => user)
                                     .Where(x => user.UserName == username)
                                     .SingleOrDefault();
            var company = GetDataSourceValue<Company>("Company");

            if (userProfile == null)
            {
                userProfile = new UserProfile();
                userProfile.User = session.QueryOver<User>().Where(x => x.UserName == username).SingleOrDefault();
            }

            userProfile.Company = company;

            DataService.SaveOrUpdate(session, userProfile);

            return new ProcessingResult(true);
        }
    }
}