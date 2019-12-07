using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ViewsModel
{
    public class ParamsBodyViewModel
    {
        public string StartDay { get; set; }
        public string StartMonth { get; set; }
        public string StartYear { get; set; }
        public string FinalDay { get; set; }
        public string FinalMonth { get; set; }
        public string FinalYear { get; set; }
        public string NumberId { get; set; }
    }
}