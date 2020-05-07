using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class SessionFeedback
    {
        [Key]
        [Column(Order = 1)]
        public int Sf_ID { get; set; }
        public int rating { get; set; }

        //[ForeignKey]
        [Column(Order = 2)]
        public int SId { get; set; }
        [ForeignKey("SId")]
        public LiveSession liveSession { get; set; }
    }
}
