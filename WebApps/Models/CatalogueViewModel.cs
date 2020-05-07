using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApps.Models
{
    public class CatalogueViewModel
    {
        public int catalogueID { get; set; }
        public string catalogueName { get; set; }
        public string catalogueType { get; set; }
        public string trainerName { get; set; }
        public float? price { get; set; }
        public float? rating { get; set; }
        public string description { get; set; }

    }
}
