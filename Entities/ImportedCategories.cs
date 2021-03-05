using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiServer_Setup.Entities
{
    public class ImportedCategories
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ImportedCategories> Categories { get; set; }
    }
}