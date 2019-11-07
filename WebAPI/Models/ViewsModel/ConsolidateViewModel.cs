using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ViewsModel
{
    public class ConsolidateViewModel
    {
        public string IdConsolidate { get; set; }
        public string CodVehicle { get; set; }
        public string NameRoute { get; set; }
        public string LapsManual { get; set; }
        public string Passenger { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
    }   
}