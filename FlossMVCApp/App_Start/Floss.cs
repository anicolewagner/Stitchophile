//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlossMVCApp.App_Start
{
    using System;
    using System.Collections.Generic;
    
    public partial class Floss
    {
        public int FlossId { get; set; }
        public int Number { get; set; }
        public string Color { get; set; }
        public decimal Skein { get; set; }
        public string Comment { get; set; }
        public int CompanyId { get; set; }
    
        public virtual Company Company { get; set; }
    }
}
