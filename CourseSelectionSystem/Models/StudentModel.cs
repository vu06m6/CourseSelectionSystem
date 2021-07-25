using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseSelectionSystem.Models
{
    public class StudentModel
    {
        [Display(Name = "流水號")]
        public string Serial { get; set; }
        [Display(Name = "學號")]
        public string Number { get; set; }
        [Display(Name = "姓名")]
        public string Name { get; set; }
        [Display(Name = "生日")]
        public string Birthday { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public StudentModel() { }
        public StudentModel(StudentMain data)
        {
            Serial = data.Serial.ToString();
            Number = data.Number;
            Name = data.Name;
            Birthday = data.Birthday.ToString("yyyy-MM-dd");
            Email = data.Email;
        }
    }
}