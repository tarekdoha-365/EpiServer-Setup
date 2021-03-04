using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EpiServer_Setup.Business;
using EpiServer_Setup.Models.Pages.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiServer_Setup.Models.Pages
{
    [ContentType(DisplayName = "ContactUsPageType", GUID = "ddabe7c4-f302-4890-9fb9-1cea8ed7d0f2", Description = "")]
    public class ContactUsPageType : SitePageData
    {
        
                [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SiteTabNames.Metadata,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
         
    }
}