using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Mvc1_student.Models;

namespace Mvc1_student.Models
{
    
    public class studentViewModel
    {
       // MvcdbEntities2 db = new MvcdbEntities2();
        [Key]
        public int std_id { get; set; }

        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are  not  allowed.")]
        public string std_name { get; set; }
        public string std_add { get; set; }
        public string std_phn { get; set; }
        public Nullable<int> std_clsid { get; set; }
        public Nullable<int> std_subid { get; set; }
        public string cls_name { get; set; }
        public string sub_one { get; set; }
        public string sub_two { get; set; }
        public string sub_three { get; set; }
    }
       
}