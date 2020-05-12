using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApps.ViewModels
{
    public class LiveSessionViewModel
    {
        public int SId { get; set; }

        public string sessionCategory { get; set; }
        public int duration { get; set; }
        public string organiser { get; set; }
        public string description { get; set; }
        public bool isPrivate { get; set; }
        public string Url { get; set; }
        public string ErrorMsg { get; set; }

        public List<SessionFeedback> sessionFeedbacks { get; set; }
    }
}
