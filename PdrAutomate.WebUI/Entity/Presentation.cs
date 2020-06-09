using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
    public class Presentation
    {
        public int PresentationId { get; set; }
        public string PresentationName { get; set; }
        public List<PresentationSession> Sessions { get; set; }
        public List<ClassPresentationsession> ClassPresentationsessions { get; set; }
        public List<StudentPresentationsession> StudentPresentationsessions { get; set; }

    }
}
