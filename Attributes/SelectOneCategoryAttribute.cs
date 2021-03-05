using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiServer_Setup.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class SelectOneCategoryAttribute: SelectOneAttribute
    {
        public string RootCategoryName { get; set; }
    }
}