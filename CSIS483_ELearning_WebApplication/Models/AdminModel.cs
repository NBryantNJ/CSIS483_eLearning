using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSIS483_ELearning_WebApplication.Models
{
    public class AdminModel
    {
        public bool doesUserHaveAdminPrivileges { get; set; }
        public List<string> allUsernames { get; set;  }
        public List<string> allCourseNames { get; set; }
    }
}
