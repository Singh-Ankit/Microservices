using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class Catalogue
    {
        [Key]
        public int catalogueID { get; set; }
        public string catalogueName { get; set; }
        public string catalogueType { get; set; }
        [Column("trainer Name")]
        public string trainerName { get; set; }
        public float? price { get; set; }
        public float? rating { get; set; }
        public string description { get; set; }
    }
}
