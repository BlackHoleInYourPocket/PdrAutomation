using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int ClassCapacity { get; set; }
        public List<Student> Students { get; set; }
        public List<ClassPresentationsession> ClassPresentationsessions { get; set; }
    }
}
