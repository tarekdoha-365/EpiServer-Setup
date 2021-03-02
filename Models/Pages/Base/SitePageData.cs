using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using EpiServer_Setup.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpiServer_Setup.Models.Pages.Base
{
    [ContentType(DisplayName = "SitePageData", GUID = "579eaeb2-a9fe-4aaa-800f-ac45bbbf6510", Description = "")]
    public abstract class SitePageData : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Heading",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }


        [Display(
        GroupName = SiteTabNames.Metadata,
        Order = 100)]
        [CultureSpecific]
        public virtual string MetaTitle
        {
            get
            {
                var metaTitle = this.GetPropertyValue(p => p.MetaTitle);
                // Use explicitly set meta title, otherwise fall back to page name
                return !string.IsNullOrWhiteSpace(metaTitle)
                ? metaTitle
                : PageName;
            }
            set { this.SetPropertyValue(p => p.MetaTitle, value); }
        }


        [Display(
        GroupName = SiteTabNames.Metadata,
        Order = 110)]
        [CultureSpecific]
        public virtual IList<string> MetaKeywords { get; set; }


        [Display(
        GroupName = SiteTabNames.Metadata,
        Order = 120)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)] // used to affect the property design in edit mode, in the examp
        public virtual string MetaDescription { get; set; }


        [Display(
        GroupName = SiteTabNames.Metadata,
        Order = 130)]
        [CultureSpecific]
        public virtual bool DisableIndexing { get; set; }


        [Display(
        GroupName = SystemTabNames.Content,
        Order = 140)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference TeaserImage { get; set; } // this property used for page, b


        [Display(GroupName = SystemTabNames.Content, Order = 150)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual XhtmlString TeaserText
        {
            get; set;
        }


        [Display(
        GroupName = SystemTabNames.Settings,
        Order = 160)]
        [CultureSpecific]
        public virtual bool HideSiteHeader { get; set; }


        [Display(
        GroupName = SystemTabNames.Settings,
        Order = 170)]
        [CultureSpecific]
        public virtual bool HideSiteFooter { get; set; }


        [CultureSpecific]
        [Display(
        Name = "Left menu",
        Description = "",
        GroupName = SystemTabNames.Content, Order = 180)]
        public virtual LinkItemCollection LeftMenu { get; set; } // this property used to add many


        [CultureSpecific]
        [Display(
        Name = "Right menu",
        Description = "",
        GroupName = SystemTabNames.Content,
        Order = 190)]
        public virtual LinkItemCollection RightMenu { get; set; }
    }
}