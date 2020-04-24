using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
    public class Sessions
    {
        public int SessionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<PresentationSession> Presentations { get; set; }
        public List<ClassPresentationsession> ClassPresentationsessions { get; set; }
        public List<StudentPresentationsession> StudentPresentationsessions { get; set; }
        public List<StudentPresentationQuestionnarieSession> StudentPresentationQuestionnarieSessions { get; set; }
    }
}
