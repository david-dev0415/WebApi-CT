using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ViewsModel
{
    public class HistoryCollectionViewTestModel
    {
        public int CodVehicle { get; set; }
        public string IdRoute { get; set; }
        public string DateStart { get; set; }
        public string DateFinal { get; set; }
        public int MinutesV { get; set; }
        public double LapsManual { get; set; }
        public int Passenger { get; set; }
        public double AmountDiscountedBrands { get; set; }
        public int Amount { get; set; }
        public int Blocks { get; set; }
        public double Kilometers { get; set; }
    }
}