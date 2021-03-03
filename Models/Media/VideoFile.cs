using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace EpiServer_Setup.Models.Media
{
    [ContentType(DisplayName = "VideoFile", GUID = "d04ac808-c6b6-469a-8d16-b645f55c8989", Description = "")]
    [MediaDescriptor(ExtensionString = "flv,mp4,webm")]
    public class VideoFile : MediaData
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
        Name = "Description",
        Description = "Description field's description",
        GroupName = SystemTabNames.Content,
        Order = 10)]
        public virtual string Description { get; set; }
        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        public virtual string Copyright { get; set; }
        /// <summary>
        /// Gets or sets the URL to the preview image.
        /// </summary>
        [UIHint(UIHint.Image)]
        public virtual ContentReference PreviewImage { get; set; }
    }
}