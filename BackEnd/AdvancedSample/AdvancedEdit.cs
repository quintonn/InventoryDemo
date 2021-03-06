﻿using InventorySystem.SiteSpecific;
using WebsiteTemplate.Backend.Services;
using WebsiteTemplate.Menus.BaseItems;

namespace InventorySystem.BackEnd.AdvancedSample
{
    public class AdvancedEdit : AdvancedModify
    {
        public AdvancedEdit(DataService dataService)
            : base(dataService, false)
        {
        }

        public override EventNumber GetId()
        {
            return MenuNumber.AdvancedEdit;
        }
    }
}