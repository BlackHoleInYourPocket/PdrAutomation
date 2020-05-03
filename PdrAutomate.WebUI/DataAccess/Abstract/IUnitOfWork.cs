using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IClassDataAccess ClassDataAccess { get; }
        IClassPresentationsession ClassPresentationsession { get; }
        IPresentationDataAccess PresentationDataAccess { get; }
        IPresentationSession PresentationSession { get; }
        ISessionsDataAccess SessionsDataAccess { get; }
        IStudentDataAccess StudentDataAccess { get; }
        IStudentPresentationsessionDataAccess studentPresentationsessionDataAccess { get; }
        IAnswerDataAccess AnswerDataAccess { get;  }
        IQuestionnarieDataAccess QuestionnarieDataAccess { get; }
        IQuestionsDataAccess QuestionsDataAccess { get; }
        IStudentQuestionnariePresentationSessionQuestionAnswerDataAccess StudentQuestionnariePresentationSessionQuestionAnswerDataAccess { get; } 
        IQuestionnarieQuestionDataAccess QuestionnarieQuestionDataAccess { get; }
        IStudentQuestionnarieQuestionAnswerDataAccess BeierStudentQuestionnarieQuestionAnswerDataAccess { get; }
        int SaveChanges();
    }
}
