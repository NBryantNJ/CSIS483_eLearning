using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSIS483_ELearning_WebApplication.Models
{
    public class TakeATestModel
    {
        public string testID { get; set; }
        public int questionNumber { get; set; }
        public string question { get; set; }
        public string answerOption1 { get; set; }
        public string answerOption2 { get; set; }
        public string answerOption3 { get; set; }
        public string answerOption4 { get; set; }
        public string isAnswerOption1Correct { get; set; }
        public string isAnswerOption2Correct { get; set; }
        public string isAnswerOption3Correct { get; set; }
        public string isAnswerOption4Correct { get; set; }

    }
}
