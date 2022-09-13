using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc1_student.Models;

namespace Mvc1_student.ViewModel
{
    public class editViewModel
    {
        public tb1_cls clss { get; set; }
        public tb1_std stud { get; set; }
        public tb1_sub subj { get; set; }
    }
}