using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSIS483_ELearning_WebApplication.Models
{
    public class RetrieveUsersReportModel
    {
        public string courseName { get; set;  }
        public string assignedBy { get; set; }
        public string dateAssigned { get; set; }
        public string dateTaken { get; set; }
        public int grade { get; set; }
    }
}
