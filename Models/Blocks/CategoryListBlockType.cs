using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EpiServer_Setup.Attributes;
using EpiServer_Setup.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiServer_Setup.Models.Blocks
{
    [ContentType(DisplayName = "CategoryListBlockType", GUID = "ad66aa23-1319-4673-afae-fe30266adab9", Description = "")]
    public class CategoryListBlockType : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Country Tag",
            Description = "Select countries to make this article visible for the employees from selected countries",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [CategorySelection(RootCategoryName = SiteConstants.Countries)]
        [UIHint(SiteUIHint.CustomCategories)]
        public virtual CategoryList Countries { get; set; }

    }
}