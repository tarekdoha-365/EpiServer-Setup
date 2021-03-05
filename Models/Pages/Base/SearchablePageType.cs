using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiServer_Setup.Models.Pages.Base
{
    [ContentType(DisplayName = "SearchablePageType", GUID = "c2950132-8f1c-4656-9cb2-a5c9b45516e1", Description = "")]
    public abstract class SearchablePageType : PageData
    {
        
    }
}