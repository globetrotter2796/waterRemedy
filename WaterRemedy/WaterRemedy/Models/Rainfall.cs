//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WaterRemedy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rainfall
    {
        public int Id { get; set; }
        public string month { get; set; }
        public double rainfall_day { get; set; }
        public double rainfall_month { get; set; }
        public double possibility { get; set; }
        public double storage_month { get; set; }
        public double indoor_req { get; set; }
        public double outdoor_req { get; set; }
    }
}
