//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Scheduler.Models
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class WorkImage
    {
        public int WorkImage_Ref { get; set; }
        public int Work_Ref { get; set; }
        public byte[] Image { get; set; }
        public Nullable<bool> IsWorkStart { get; set; }
    
        public virtual Work Work { get; set; }
    }
}