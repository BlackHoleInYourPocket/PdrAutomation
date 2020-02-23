using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentSchoolId { get; set; }
        public string Password { get; set; }
        public StudentClass ClassId { get; set; }
        public string StudentName { get; set; }

    }
}
