﻿using InventorySystem.Models.Samples;
using InventorySystem.SiteSpecific;
using System.Collections.Generic;
using WebsiteTemplate.Menus.BaseItems;
using WebsiteTemplate.Menus.BasicCrudItems;

namespace InventorySystem.BackEnd.BasicCrudSample
{
    public class CategoryCrudMenuItem : BasicCrudMenuItem<SampleCategory>
    {
        public override bool AllowInMenu => true;

        public override string UniquePropertyName => "Description"; // Will prevent duplicate items using Description as check

        public override string GetBaseItemName()
        {
            return "Category";
        }

        public override EventNumber GetBaseMenuId()
        {
            return MenuNumber.ViewSampleCategories;
        }

        public override Dictionary<string, string> GetColumnsToShowInView()
        {
            return new Dictionary<string, string>()
            {
                { "Description", "Description" }
            };
        }

        public override Dictionary<string, string> GetInputProperties()
        {
            return new Dictionary<string, string>()
            {
                { "Description", "Description" }
            };
        }
    }
}