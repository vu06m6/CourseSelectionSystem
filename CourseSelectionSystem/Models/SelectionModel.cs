using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CourseSelectionSystem.Models
{
    public class SelectionModel
    {
        [Display(Name = "學號")]
        public string StudentNumber { get; set; }
        [Display(Name = "課程")]
        public string Course { get; set; }
        public List<string> CheckedCourse { get; set; }
    }
}