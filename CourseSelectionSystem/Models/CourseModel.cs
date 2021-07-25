using System.ComponentModel.DataAnnotations;

namespace CourseSelectionSystem.Models
{
    public class CourseModel
    {
        [Display(Name = "流水號")]
        public string Serial { get; set; }
        [Display(Name = "課號")]
        public string Number { get; set; }
        [Display(Name = "課名")]
        public string Name { get; set; }
        [Display(Name = "學分數")]
        public string Credits { get; set; }
        [Display(Name = "上課地點")]
        public string Location { get; set; }
        [Display(Name = "講師名字")]
        public string LecturerName { get; set; }
    }
}