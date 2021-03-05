using EpiServer_Setup.Entities;
using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiServer_Setup.Interfaces
{
    public interface ITagService
    {
        IEnumerable<Tag> GetTagTree(string tag, List<int> selectedIDs = null, List<int> userSectionsIDs = null);
        Tag GetTag(int categoryId);
        IEnumerable<Tag> GetTags(CategoryList categoryList);
        string GetFirstOrDefaultTag(CategoryList categoryList);
        int GetFirstOrDefaultCategoryId(CategoryList categoryList);
        IEnumerable<string> GetCatNames(CategoryList categoryList);
        IEnumerable<string> GetCatNames(List<int> categoryList);
        IEnumerable<int> GetTagParentsIds(int tagId);
        IEnumerable<int> GetTagParentsIds(string tag);
        int GetRootDepartmentId(int tagId);
        int? GetTagId(string tagName);
        int GetDepartmentTagId(string TagName);
        CategoryList GetSectionsByNames(List<string> categoryNames);
        void CreateCategoriesTree(List<ImportedCategories> importedCategories);
        string GetTagName(int tagId);
        IEnumerable<int> GetNotExsistTagsIds(List<int> list);
    }
}
