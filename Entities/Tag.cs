using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpiServer_Setup.Entities
{
    public class Tag
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public bool Active { get; set; }
        public bool Locked { get; set; }
        public IEnumerable<Tag> Children { get; set; }
    }
}