using PdrAutomate.WebUI.DataAccess.Abstract;
using PdrAutomate.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.DataAccess.Concrete.EntityFramework
{
    public class EfPresentationDataAccess : EfGenericDataAccess<Presentation>, IPresentationDataAccess
    {
        public EfPresentationDataAccess(PdrAutomateContext context) : base(context)
        {

        }

        public PdrAutomateContext PdrAutomateContext
        {
            get { return context as PdrAutomateContext; }
        }

    }
}
