using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ViewsModel
{
    public class HistoryCollectionViewModel
    {
        public string IdHistoryCollection { get; set; }
        public string IdVehicle { get; set; }
        public string IdRoute { get; set; }
        public string IdSector { get; set; }        
        public string IdRegistry { get; set; }
        public string IdRegistryRealTime { get; set; }
        public string InRoute { get; set; }
        public string InSector { get; set; }    
        public int InVehicle { get; set; }
        public int InHistoryRealTime { get; set; }
        public string InRegistryRealTime { get; set; }
        public string Month { get; set; }
        public string DateStart  { get; set; }
        public string DateFinal { get; set; }
        public string MinutesV { get; set; }
        public string Passenger { get; set; }
        public string Amount { get; set; }
        public string Kilometers { get; set; }
        public string LapsManual { get; set; }       
        public string AmountDiscountedBrands { get; set; }
        public string Blocks { get; set; }
        public string UpsDoorOne { get; set; }
        public int DownsDoorOne { get; set; }
        public int BlocksDoorOne { get; set; }
        public int UpsDoorTwo { get; set; }
        public int DownsDoorTwo { get; set; }
        public int BlocksDoorTwo { get; set; }       
    }
}