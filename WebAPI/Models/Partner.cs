//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Partner
    {
        public Nullable<long> NumberId { get; set; }
        public string NameOwner { get; set; }
        public string IdUser { get; set; }
        public int InPartner { get; set; }
    
        public virtual PartnerVehicleDetails PartnerVehicleDetails { get; set; }
        public virtual User User { get; set; }
    }
}