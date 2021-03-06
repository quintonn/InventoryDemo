﻿using System;
using Owin;
using Unity;
using WebsiteTemplate.Backend.Users;
using WebsiteTemplate.Utilities;

namespace InventorySystem.SiteSpecific
{
    public class AppSettings : ApplicationSettingsCore
    {
        public override bool EnableAuditing => false; // Will audit everything

        public override bool DebugStartup => false; //  will create a window to allow debugging when starting if true

        public override bool UpdateDatabase => true; // Set to true first time to create tables. Also set to true after making changes

        public override string ApplicationPassPhrase => "xxxxxx"; // This is used for encrypting/decrypting password inputs. Should be different for each project

        public override Type GetApplicationStartupType => typeof(Startup);

        public override string SystemEmailAddress => "system@example.com";

        public override string GetApplicationName()
        {
            return "InventorySystem";
        }

        public override void PerformAdditionalStartupConfiguration(IAppBuilder app, IUnityContainer container)
        {
            container.RegisterType<UserInjector, InventorySystemUserInjector>();
        }
    }
}