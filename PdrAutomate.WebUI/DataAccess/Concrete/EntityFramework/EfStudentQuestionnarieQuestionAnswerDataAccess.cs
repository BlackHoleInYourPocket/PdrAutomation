using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PdrAutomate.WebUI.DataAccess.Abstract;
using PdrAutomate.WebUI.Entity;

namespace PdrAutomate.WebUI.DataAccess.Concrete.EntityFramework
{
	public class EfStudentQuestionnarieQuestionAnswerDataAccess : EfGenericDataAccess<StudentQuestionnarieQuestionAnswer>, IStudentQuestionnarieQuestionAnswerDataAccess
    {
        public EfStudentQuestionnarieQuestionAnswerDataAccess(PdrAutomateContext context) : base(context)
        {

        }

        public PdrAutomateContext PdrAutomateContext
        {
            get { return context as PdrAutomateContext; }
        }
    }
}
