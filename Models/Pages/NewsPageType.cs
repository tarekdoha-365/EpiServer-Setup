using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using EPiServer.Web.Routing;
using EpiServer_Setup.Attributes;
using EpiServer_Setup.Entities;
using EpiServer_Setup.Models.Blocks;
using EpiServer_Setup.Models.Pages.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiServer_Setup.Models.Pages
{
    [ContentType(DisplayName = "NewsPageType", GUID = "d335db5d-7023-4852-a601-b64919696e0a", Description = "")]
    public class NewsPageType : SearchablePageType
    {

        [Display(
                 Name = "Filter Tags",
                 Description = "Select tags to make this article filterd by it",
                 GroupName = SystemTabNames.Content,
                 Order = 10)]
        public virtual CategoryListBlockType FilterTags { get; set; }
        [CultureSpecific]
        [Display(
            Name = "Article Title",
            Description = "Article Title",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [Required]
        //[MaxLength(6, ErrorMessage ="This is my custom error message")]
        [Alphanumeric]
        public virtual string ArticleTitle { get; set; }

        [Display(
            Name = "Article Image",
            Description = "Select an image to be the main article image",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference ArticleImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Article Summary",
            Description = "Article Summary",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        [UIHint(UIHint.Textarea)]
        public virtual string ArticleSummary { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Full Article",
            Description = "Full Article",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual XhtmlString FullArticle { get; set; }
        internal News GetSerializableNews()
        {
            return new News()
            {
                Guid = ContentGuid,
                ArticleTitle = ArticleTitle,
                ArticleSummary = ArticleSummary,
                FullArticle = FullArticle?.ToHtmlString(),
                ArticleImage = ArticleImage != null ? UrlResolver.Current.GetUrl(ArticleImage) : "",
                Created = Created.ToString("yyyy-MM-ddTHH:mm:ss"),
                Modified = Saved.ToString("yyyy-MM-ddTHH:mm:ss"),
                CreatedBy = CreatedBy,
                ModifiedBy = ChangedBy
            };
        }

    }
}