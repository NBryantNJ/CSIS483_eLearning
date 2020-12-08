using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSIS483_ELearning_WebApplication.Models
{
    public class createACourseModel
    {
        public int numberOfLinks { get; set; }
        public string link { get; set;  }
        public string linkType { get; set; }
        public int numberOfQuestions { get; set; }
        public string question { get; set; }
        public string option1 { get; set;  }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public string isOptionCorrectOrIncorrect1 { get; set; }
        public string isOptionCorrectOrIncorrect2 { get; set; }
        public string isOptionCorrectOrIncorrect3 { get; set; }
        public string isOptionCorrectOrIncorrect4 { get; set; }
        public string difficultyRating { get; set; }
        public string courseName { get; set; }
        public string notes { get; set; }
    }
}
