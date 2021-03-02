using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiServer_Setup.Models.Pages.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiServer_Setup.Models.Pages
{
    [ContentType(DisplayName = "StartPageType", GUID = "a1aa52be-8ad0-4de8-bd80-1050e5e4175b", Description = "")]
    public class StartPageType : SitePageData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
         */
    }
}