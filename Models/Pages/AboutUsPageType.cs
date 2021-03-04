using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiServer_Setup.Models.Pages.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiServer_Setup.Models.Pages
{
    [ContentType(DisplayName = "AboutUsPageType", GUID = "9b77d13b-c1d8-474f-9ddb-bd8d2fca64a5", Description = "")]
    public class AboutUsPageType : SitePageData
    {
        
                [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
         
    }
}