using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
    public class PresentationSession
    {
        public int PresentationID { get; set; }
        public Presentation Presentation { get; set; }
        public int SessionId { get; set; }
        public Sessions Sessions { get; set; }
    }
}
