using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseSelectionSystem.Models
{
    public class StudentModel2
    {
        public string Serial { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
    }
}