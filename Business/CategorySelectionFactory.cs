using EPiServer.Shell.ObjectEditing;
using EpiServer_Setup.Attributes;
using EpiServer_Setup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiServer_Setup.Business
{
    [SelectionFactoryRegistration]
    public class CategorySelectionFactory : ISelectionFactory
    {
        private readonly ITagService _tagService;
        public CategorySelectionFactory(ITagService tagService)
        {
            _tagService = tagService;
        }
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var myAttribute = metadata.Attributes.OfType<SelectOneCategoryAttribute>().SingleOrDefault();

            var TagList = _tagService.GetTagTree(myAttribute.RootCategoryName);
            var selectItems = new List<ISelectItem>();

            if (TagList != null)
            {
                foreach (var tag in TagList)
                {
                    var tagSelectItem = new SelectItem()
                    {
                        Text = tag.Description,
                        Value = tag.Id
                    };

                    selectItems.Add(tagSelectItem);
                }

            }
            return selectItems;
        }
    }
}