using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class LiveSession
    {
        [Key]
        [Column(Order = 1)]
        public int SId { get; set; }
        [Column("category")]
        public string sessionCategory { get; set; }
        public int duration { get; set; }
        public string organiser { get; set; }
        public string description { get; set; }
        public bool isPrivate { get; set; }
        public string Url { get; set; }

        public List<SessionFeedback> sessionFeedbacks { get; set; }
    }
}
