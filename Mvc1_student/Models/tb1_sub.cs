//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mvc1_student.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb1_sub
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb1_sub()
        {
            this.tb1_std = new HashSet<tb1_std>();
        }
    
        public int sub_id { get; set; }
        public string sub_one { get; set; }
        public string sub_two { get; set; }
        public string sub_three { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb1_std> tb1_std { get; set; }
    }
}