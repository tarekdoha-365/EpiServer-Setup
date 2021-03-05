using EPiServer.Core;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using EpiServer_Setup.Attributes;
using EpiServer_Setup.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiServer_Setup.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(CategoryList), UIHint = SiteUIHint.CustomCategories, EditorDescriptorBehavior = EditorDescriptorBehavior.ExtendBase)]
    public class CustomCategoryListEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(
           ExtendedMetadata metadata,
           IEnumerable<Attribute> attributes)
        {

            base.ModifyMetadata(metadata, attributes);
            var categorySelectionAttribute =
                attributes.OfType<CategorySelectionAttribute>().FirstOrDefault();

            if (categorySelectionAttribute != null)
            {
                metadata.EditorConfiguration["root"] =
                    categorySelectionAttribute.GetRootCategoryId();
                return;
            }

            var contentTypeCategorySelectionAttribute =
                metadata.ContainerType.GetCustomAttributes(true).FirstOrDefault() as CategorySelectionAttribute;

            if (contentTypeCategorySelectionAttribute != null)
            {
                metadata.EditorConfiguration["root"] =
                    contentTypeCategorySelectionAttribute.GetRootCategoryId();
            }
        }
    }
}