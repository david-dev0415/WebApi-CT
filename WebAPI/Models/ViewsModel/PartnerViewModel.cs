using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.ViewsModel
{
    public class PartnerViewModel
    {
        private string _CodVehicle;
        private string _LapsManual;
        private string _Passenger;
        private string _Day;
        private string _Month;
        private string _Year;
        public PartnerViewModel(
            string ACodVehicle, string ALapsManual, string APassenger, string ADay,
            string AMonth, string AYear)
        {
            _CodVehicle = ACodVehicle;
            _LapsManual = ALapsManual;
            _Passenger = APassenger;
            _Day = ADay;
            _Month = AMonth;
            _Year = AYear;
        }
        public string CodVehicle { get { return _CodVehicle; } }
        public string LapsManual { get { return _LapsManual; } }
        public string Passenger { get { return _Passenger; } }
        public string Day { get { return _Day; } }
        public string Month { get { return _Month; } }
        public string Year { get { return _Year; } }
    }
}