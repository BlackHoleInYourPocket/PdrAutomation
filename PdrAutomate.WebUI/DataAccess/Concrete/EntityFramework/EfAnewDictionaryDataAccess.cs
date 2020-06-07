using PdrAutomate.WebUI.DataAccess.Abstract;
using PdrAutomate.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.DataAccess.Concrete.EntityFramework
{
    public class EfAnewDictionaryDataAccess : EfGenericDataAccess<AnewDictionary>, IAnewDictionaryDataAccess
    {
        public EfAnewDictionaryDataAccess(PdrAutomateContext context) : base(context)
        {

        }

        public PdrAutomateContext PdrAutomateContext
        {
            get { return context as PdrAutomateContext; }
        }

    }
}
