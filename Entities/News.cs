using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiServer_Setup.Entities
{
    public class News
    {
        public Guid Guid { get; set; }
        public string Created { get; set; }
        public string CreatedBy { get; set; }
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleImage { get; set; }
        public string ArticleSummary { get; set; }
        public string FullArticle { get; set; }
    }
}