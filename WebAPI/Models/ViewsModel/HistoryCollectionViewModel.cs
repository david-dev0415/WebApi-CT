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
        public string DateStart { get; set; }
        public string DateFinal { get; set; }
        public int MinutesV { get; set; }
        public int Passenger { get; set; }
        public int Amount { get; set; }
        public float Kilometers { get; set; }
        public float Laps { get; set; }
        public string IdSector { get; set; }
        public float LapsManual { get; set; }
        public string IdRegistry { get; set; }
        public float InRegistry { get; set; }
        public float InSector { get; set; }
        public float InRoutes { get; set; }        
        public float AmountDiscountedBrands { get; set; }
        public int Blocks { get; set; }
        public int UpsDoorOne { get; set; }
        public int DowsDoorOne { get; set; }
        public int BlocksDoorOne { get; set; }
        public int UpsDoorTwo { get; set; }
        public int DowsDoorTwo { get; set; }
        public int BlocksDoorTwo { get; set; }
        public int InVehicle { get; set; }
        public float InHistoryRealTime { get; set; }
        public int DiscountedBrands { get; set; }
        // public string IdRegistryRealTime { get; set; }
        public string IdConsolidate { get; set; }
        // public string InRegistryRealTime { get; set; }
       
    }
}