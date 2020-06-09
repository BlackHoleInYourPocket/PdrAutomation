using PdrAutomate.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Models
{
    public class BeierResult
    {
        public Student Student { get; set; }
        public double Valance { get; set; }
        public double Dominanace { get; set; }
        public double Arousal { get; set; }
        public String Result { get; set; }

    }
}
