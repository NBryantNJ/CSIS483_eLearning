using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSIS483_ELearning_WebApplication.Models
{
    public class CourseContentModel
    {
        public string courseTitle { get; set; }
        public string difficultyRating { get; set; }
        public List<string> webAndPDFLinks { get; set; }
        public List<string> videoLinks { get; set; }
        public string notes { get; set; }

    }
}
