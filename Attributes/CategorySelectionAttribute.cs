using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiServer_Setup.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CategorySelectionAttribute: Attribute
    {
        //Root ID Category
        public int RootCategoryId { get; set; }

        //Root Name Category
        public string RootCategoryName { get; set; }
        public int GetRootCategoryId()
        {
            if (RootCategoryId > 0)
            {
                return RootCategoryId;
            }
            var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
            if (!string.IsNullOrWhiteSpace(RootCategoryName))
            {
                var category = categoryRepository.Get(RootCategoryName);

                if (category != null)
                {
                    return category.ID;
                }
            }

            return categoryRepository.GetRoot().ID;
        }
    }
}