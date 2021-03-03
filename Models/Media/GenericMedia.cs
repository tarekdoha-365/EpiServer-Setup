using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace EpiServer_Setup.Models.Media
{
    [ContentType(DisplayName = "GenericMedia", GUID = "ff441b4d-94a3-4640-b303-6cb72a7d4ecc", Description = "")]
    [MediaDescriptor(ExtensionString = "pdf,doc,docx,ppt,pptx,xls,xlsx")]
    public class GenericMedia : MediaData
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
        Name = "Description",
        Description = "Description field's description",
        GroupName = SystemTabNames.Content,
        Order = 10)]
        public virtual string Description { get; set; }
    }
}