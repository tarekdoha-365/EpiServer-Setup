# EPI Server Create basic media classes
[1.Create GenericMedia class](#GenericMedia)

[2.Create ImageFile class](#ImageFile)

[3.Create VideoFile class](#VideoFile)


<div id="GenericMedia">
1- Create GenericMedia class:
in Infrastructure.Models.Media create GenericMedia.cs and use this code:

```
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
namespace Infrastructure.Models.Media
{
[ContentType(DisplayName = "GenericMedia", GUID = "ff441b4d-94a3-4640-b303-6cb72a7d4ecc", Descr [MediaDescriptor(ExtensionString = "pdf,doc,docx,ppt,pptx,xls,xlsx")]
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
```
</div>
<div id="ImageFile">
2- Create ImageFile class:
in Infrastructure.Models.Media create ImageFile.cs and use this code:

```
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
namespace Infrastructure.Models.Media
{
[ContentType(DisplayName = "ImageFile", GUID = "50264228-bdbb-442e-92b0-9fb0a437080f", Descript [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png,svg")]
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
```
</div>
<div id="VideoFile">

3- Create VideoFile class:
in Infrastructure.Models.Media create ImageFile.cs and use this code:
```
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
namespace Infrastructure.Models.Media
{
[ContentType(DisplayName = "VideoFile", GUID = "d04ac808-c6b6-469a-8d16-b645f55c8989", Descript [MediaDescriptor(ExtensionString = "flv,mp4,webm")]
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
/// /// Gets or sets the copyright. ///
public virtual string Copyright { get; set; }
/// /// Gets or sets the URL to the preview image. ///
[UIHint(UIHint.Image)]
public virtual ContentReference PreviewImage { get; set; }
}
}
```
</div>

