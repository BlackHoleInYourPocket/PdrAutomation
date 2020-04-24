using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdrAutomate.WebUI.DataAccess.Abstract;
using PdrAutomate.WebUI.Entity;

namespace PdrAutomate.WebUI.Controllers
{
    [Authorize]
    public class QuestionnarieController : Controller
    {
        IUnitOfWork uow;
        public QuestionnarieController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public IActionResult PresentationQuestionnarieIndex(string studentSchoolId)
        {
            List<ClassPresentationsession> returnList = new List<ClassPresentationsession>();
            var studentId = uow.StudentDataAccess
                            .GetAll()
                            .Where(i => i.StudentSchoolId == studentSchoolId)
                            .FirstOrDefault()
                            .StudentId;

            var registeredPresentations = uow.studentPresentationsessionDataAccess
                            .GetAll()
                            .Where(i => i.StudentId == studentId)
                            .ToList();

            foreach (var presentation in registeredPresentations)
            {
                var item = new ClassPresentationsession();

                item.PresentationId = presentation.PresentationId;
                item.Presentation = uow.PresentationDataAccess
                            .GetAll()
                            .Where(i => i.PresentationId == item.PresentationId)
                            .FirstOrDefault();
                item.SessionId = presentation.SessionId;
                item.Sessions = uow.SessionsDataAccess
                            .GetAll()
                            .Where(i => i.SessionId == item.SessionId)
                            .FirstOrDefault();
                var classInfos = uow.ClassPresentationsession
                            .GetAll()
                            .Where(i => i.PresentationId == item.PresentationId
                            && i.SessionId == item.SessionId)
                            .FirstOrDefault();

                item.CurrentCapacity = classInfos.CurrentCapacity;
                item.Class = uow.ClassDataAccess
                            .GetAll()
                            .Where(i => i.ClassId == classInfos.ClassId)
                            .FirstOrDefault();
                returnList.Add(item);
            }

            return View(returnList);
        }

        public IActionResult PresentationQuestionnarie(int presentationId,int sessionId,string questionnarieName)
        {
            List<Question> returnList = new List<Question>();
            var questionnarieId = uow.QuestionnarieDataAccess
                .GetAll()
                .Where(i => i.QuestionnarieName.Equals(questionnarieName))
                .FirstOrDefault()
                .QuestionnarieId;
            var questions = uow.QuestionnarieQuestionDataAccess
                .GetAll()
                .Where(i => i.QuestionnarieId.Equals(questionnarieId))
                .ToList();
            foreach(var question in questions)
            {
                returnList.Add(question.Question = uow.QuestionsDataAccess
                    .Get(question.QuestionId));
            }
            return View(returnList);
        }
        public IActionResult PersonalQuestionnarieIndex()
        {
            return View();
        }
    }
}