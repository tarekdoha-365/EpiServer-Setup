using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace EpiServer_Setup.Models.Media
{
    [ContentType(DisplayName = "ImageFile", GUID = "50264228-bdbb-442e-92b0-9fb0a437080f", Description = "")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png,svg")]
    public class ImageFile : ImageData
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
        Name = "Description",
        Description = "Description field's description",
        GroupName = SystemTabNames.Content,
        Order = 10)]
        public virtual string Description { get; set; }

        [CultureSpecific]
        [Editable(true)]
        [Display(
        Name = "AlternativeText",
        Description = "AlternativeText field's description",
        GroupName = SystemTabNames.Content,
        Order = 20)]
        public virtual string AlternativeText { get; set; }
    }
}