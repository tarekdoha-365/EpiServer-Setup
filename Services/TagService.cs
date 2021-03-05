using EPiServer.Core;
using EPiServer.DataAbstraction;
using EpiServer_Setup.Entities;
using EpiServer_Setup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiServer_Setup.Services
{
    public class TagService : ITagService
    {
        private readonly CategoryRepository _categoryRepository;
        public TagService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IEnumerable<Tag> GetTagTree(string tag, List<int> selectedIDs = null, List<int> userSectionsIDs = null)
        {
            var taggRoot = _categoryRepository.Get(tag);
            var tags = GetTagHierarchyRecursive(taggRoot, selectedIDs, userSectionsIDs);
            return tags;
        }

        public Tag GetTag(int categoryId)
        {
            var tag = _categoryRepository.Get(categoryId);
            return new Tag()
            {
                Name = tag.Name,
                Description = tag.Description,
                Id = tag.ID,
                Children = null,
                Active = false,
                Locked = false
            };
        }

        public CategoryList GetSectionsByNames(List<string> categoryNames)
        {
            var sectionCategories = _categoryRepository.GetRoot();
            var list = new CategoryList();
            foreach (var cat in categoryNames)
            {
                var foundCategory = sectionCategories.FindChild(cat);
                if (foundCategory != null)
                {
                    list.Add(foundCategory.ID);
                }
            }
            return list;
        }

        public string GetTagName(int tagId)
        {
            if (tagId == 0)
            {
                return string.Empty;
            }
            return _categoryRepository.Get(tagId).Name;
        }

        public IEnumerable<int> GetNotExsistTagsIds(List<int> list)
        {
            foreach (var item in list)
            {
                if (_categoryRepository.Get(item) == null)
                {
                    yield return item;
                }
            }
        }
        public int GetRootDepartmentId(int tagId)
        {
            int parent = 0;
            var currentTag = _categoryRepository.Get(tagId);

            while (currentTag.Parent.Name != _categoryRepository.GetRoot().Name)
            {
                parent = currentTag.Parent.ID;
                currentTag = currentTag.Parent;
            }
            string cat;
            if (parent == 0)
            {
                cat = currentTag.Name;
            }
            else
            {
                cat = _categoryRepository.Get(parent).Name;
            }
            parent = GetTagTree(_categoryRepository.GetRoot().Name).Single(x => x.Name == cat).Id;
            return parent;
        }
        public IEnumerable<int> GetTagParentsIds(int tagId)
        {
            var parents = new List<int>();
            var currentTag = _categoryRepository.Get(tagId);
            while (currentTag.Parent.Name != _categoryRepository.GetRoot().Name)
            {
                parents.Add(currentTag.Parent.ID);
                currentTag = currentTag.Parent;
            }
            return parents;
        }
        public IEnumerable<int> GetTagParentsIds(string tag)
        {
            var parents = new List<int>();
            var currentTag = _categoryRepository.Get(tag);
            while (currentTag.Parent.Name != _categoryRepository.GetRoot().Name)
            {
                parents.Add(currentTag.Parent.ID);
                currentTag = currentTag.Parent;
            }
            return parents;
        }

        public IEnumerable<Tag> GetTags(CategoryList categoryList)
        {
            if (categoryList == null) yield break;
            foreach (var categoryId in categoryList)
            {
                var category = _categoryRepository.Get(categoryId);
                if (category == null)
                {
                    continue;
                }
                var tag = new Tag()
                {
                    Description = category.Description,
                    Id = category.ID,
                    Name = category.Name
                };
                yield return tag;
            }
        }

        public string GetFirstOrDefaultTag(CategoryList categoryList)
        {
            var departmentTagId = GetFirstOrDefaultCategoryId(categoryList);
            return departmentTagId == 0 ? string.Empty : _categoryRepository.Get(departmentTagId).Name;
        }

        public int GetFirstOrDefaultCategoryId(CategoryList categoryList)
        {
            if (categoryList == null)
            {
                return 0;
            }
            return categoryList.FirstOrDefault();
        }

        internal IEnumerable<Tag> GetTagHierarchyRecursive(Category category, List<int> selectedIDs, List<int> userSectionsIDs)
        {
            return category.Categories.Select(item => new Tag()
            {
                Name = item.Name,
                Description = item.Description,
                Id = item.ID,
                Children = GetTagHierarchyRecursive(item, selectedIDs, userSectionsIDs),
                Active = ((selectedIDs != null) && selectedIDs.IndexOf(item.ID) != -1) || ((userSectionsIDs != null) && userSectionsIDs.IndexOf(item.ID) != -1) ? true : false,
                Locked = ((userSectionsIDs != null) && userSectionsIDs.IndexOf(item.ID) != -1) ? true : false
            })
                .ToList();
        }

        public IEnumerable<string> GetCatNames(CategoryList categoryList)
        {
            foreach (var item in categoryList)
            {
                var cat = _categoryRepository.Get(item);
                if (cat == null)
                {
                    continue;
                }
                yield return cat.Name;
            }
        }
        public IEnumerable<string> GetCatNames(List<int> categoryList)
        {
            foreach (var item in categoryList)
            {
                var cat = _categoryRepository.Get(item);
                if (cat == null)
                {
                    continue;
                }
                yield return cat.Name;
            }
        }

        public int? GetTagId(string tagName)
        {
            var category = _categoryRepository.Get(tagName.Trim());
            if (category == null)
                return null;
            return category.ID;
        }

        public int GetDepartmentTagId(string tagName)
        {
            //TODO: this probably need to be rewritten, using to much nested code to do such small thing
            return GetTagTree(_categoryRepository.GetRoot().Name).Single(x => x.Name == tagName).Id;
        }

        private void CreateCategory(Category parent, ImportedCategories child)
        {
            var parentCategory = parent.CreateWritableClone();
            var name = child.Name;
            var childCategory = new Category(parentCategory, name);
            childCategory.Description = (string.IsNullOrEmpty(child.Description)) ? child.Name : child.Description;
            _categoryRepository.Save(childCategory);
            foreach (var grandChild in child.Categories)
            {
                CreateCategory(childCategory, grandChild);
            }
        }
        public void CreateCategoriesTree(List<ImportedCategories> importedCategories)
        {
            var root = _categoryRepository.Get(_categoryRepository.GetRoot().Name);
            var categories = new List<Category>();
            foreach (var importedCategory in importedCategories)
            {
                CreateCategory(root, importedCategory);
            }
        }
    }
}