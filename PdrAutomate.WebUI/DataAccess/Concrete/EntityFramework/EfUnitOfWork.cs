using PdrAutomate.WebUI.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.DataAccess.Concrete.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly PdrAutomateContext dbContext;
        public EfUnitOfWork(PdrAutomateContext _dbContext)
        {
            dbContext = _dbContext ?? throw new ArgumentNullException("db null");
        }
        private IClassDataAccess _ClassDataAccess;
        private IClassPresentationsession _ClassPresentationsession;
        private IPresentationDataAccess _PresentationDataAccess;
        private IPresentationSession _PresentationSession;
        private ISessionsDataAccess _SessionsDataAccess;
        private IStudentDataAccess _StudentDataAccess;
        private IStudentPresentationsessionDataAccess _studentPresentationsessionDataAccess;
        private IAnswerDataAccess _AnswerDataAccess;
        private IQuestionnarieDataAccess _QuestionnarieDataAccess;
        private IQuestionsDataAccess _QuestionsDataAccess;
        private IStudentQuestionnarieQuestionAnswerDataAccess _StudentQuestionnarieQuestionAnswerDataAccess;
        private IStudentPresentationQuestionnarieSessionDataAccess _StudentPresentationQuestionnarieSessionDataAccess;
        private IQuestionnarieQuestionDataAccess _QuestionnarieQuestionDataAccess;
        public IClassDataAccess ClassDataAccess
        {
            get
            {
                return _ClassDataAccess ?? (_ClassDataAccess = new EfClassDataAccess(dbContext));
            }
        }

        public IClassPresentationsession ClassPresentationsession
        {
            get
            {
                return _ClassPresentationsession ?? (_ClassPresentationsession = new EfClassPresentationsession(dbContext));
            }
        }
        public IPresentationDataAccess PresentationDataAccess
        {
            get
            {
                return _PresentationDataAccess ?? (_PresentationDataAccess = new EfPresentationDataAccess(dbContext));
            }
        }
        public IPresentationSession PresentationSession
        {
            get
            {
                return _PresentationSession ?? (_PresentationSession = new EfPresentationSession(dbContext));
            }
        }
        public ISessionsDataAccess SessionsDataAccess
        {
            get
            {
                return _SessionsDataAccess ?? (_SessionsDataAccess = new EfSessions(dbContext));
            }
        }
        public IStudentDataAccess StudentDataAccess
        {
            get
            {
                return _StudentDataAccess ?? (_StudentDataAccess = new EfStudentDataAccess(dbContext));
            }
        }
        public IStudentPresentationsessionDataAccess studentPresentationsessionDataAccess
        {
            get
            {
                return _studentPresentationsessionDataAccess ?? (_studentPresentationsessionDataAccess = new EfStudentPresentationsession(dbContext));
            }
        }


        public IAnswerDataAccess AnswerDataAccess
        {
            get
            {
                return _AnswerDataAccess ?? (_AnswerDataAccess = new EfAnswerDataAccess(dbContext));

            }
        }
        public IQuestionnarieDataAccess QuestionnarieDataAccess
        {
            get
            {
                return _QuestionnarieDataAccess ?? (_QuestionnarieDataAccess = new EfQuestionnarieDataAccess(dbContext));

            }
        }
        public IQuestionsDataAccess QuestionsDataAccess
        {
            get
            {
                return _QuestionsDataAccess ?? (_QuestionsDataAccess = new EfQuestionsDataAccess(dbContext));

            }
        }
        public IStudentQuestionnarieQuestionAnswerDataAccess StudentQuestionnarieQuestionAnswerDataAccess
        {
            get
            {
                return _StudentQuestionnarieQuestionAnswerDataAccess ?? (_StudentQuestionnarieQuestionAnswerDataAccess = new EfStudentQuestionnarieQuestionAnswerDataAccess(dbContext));

            }
        }

        public IStudentPresentationQuestionnarieSessionDataAccess StudentPresentationQuestionnarieSessionDataAccess
        {
            get
            {
                return _StudentPresentationQuestionnarieSessionDataAccess ?? (_StudentPresentationQuestionnarieSessionDataAccess = new EfStudentPresentationQuestionnarieSessionDataAccess(dbContext));

            }
        }

        public IQuestionnarieQuestionDataAccess QuestionnarieQuestionDataAccess
        {
            get
            {
                return _QuestionnarieQuestionDataAccess ?? (_QuestionnarieQuestionDataAccess = new EfQuestionnarieQuestionDataAccess(dbContext));

            }
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }

        public int SaveChanges()
        {
            try
            {
                return dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

