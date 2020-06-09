using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
    public class AnewDictionary
    {
        public int AnewDictionaryId { get; set; }
        public string TurkishContent { get; set; }
        public string EnglishContent { get; set; }
        public double Valance { get; set; }
        public double Arousal { get; set; }
        public double Dominance { get; set; }

    }
}
