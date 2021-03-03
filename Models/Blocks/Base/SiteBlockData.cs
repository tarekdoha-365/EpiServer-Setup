using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiServer_Setup.Models.Blocks.Base
{
    [ContentType(DisplayName = "SiteBlockData", GUID = "f7479944-e05e-4240-9913-f0e8630e7880", Description = "")]
    public class SiteBlockData : BlockData
    {
        [Display(Name = "Heading", Description = "Heading", GroupName = SystemTabNames.Content, Order = 10)]
        public virtual string Heading { get; set; }
    }
}