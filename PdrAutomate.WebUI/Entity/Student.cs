using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string StudentSchoolId { get; set; }
        public string Password { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public List<StudentPresentationsession> StudentPresentationsessions { get; set; }
    }
}
