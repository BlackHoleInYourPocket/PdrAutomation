using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
    public class PresentationClass
    {
        public int PresentationId { get; set; }
        public Presentation Presentation { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int CurrentCapacity { get; set; }
        public int Section { get; set; }
    }
}
