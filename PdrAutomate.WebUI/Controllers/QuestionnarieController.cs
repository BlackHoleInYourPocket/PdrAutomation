using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdrAutomate.WebUI.DataAccess.Abstract;
using PdrAutomate.WebUI.Entity;
using PdrAutomate.WebUI.Models;

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
            QuestionPresentation returnModel = new QuestionPresentation();
            returnModel.PresentationId = presentationId;
            returnModel.SessionId = sessionId;
            List<Question> questionList = new List<Question>();
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
                questionList.Add(question.Question = uow.QuestionsDataAccess
                    .Get(question.QuestionId));
            }
            returnModel.Questions = questionList;
            return View(returnModel);
        }
        public string SendPresentationQuestionnarie(string schoolId,int presentationId,int sessionId,string answers)
        {
            int studentId = uow.StudentDataAccess
                    .GetAll()
                    .Where(c => c.StudentSchoolId == schoolId)
                    .FirstOrDefault()
                    .StudentId;

            int questionnarieId = uow.QuestionnarieDataAccess
                .GetAll()
                .Where(c => c.QuestionnarieName == "Before")
                .FirstOrDefault()
                .QuestionnarieId;
            try
            {
                var questionIdAnswer = Newtonsoft.Json.JsonConvert.DeserializeObject<string[][]>(answers);
                for (int i = 0; i < questionIdAnswer.Length; i++)
                {
                    switch (questionIdAnswer[i][1])
                    {
                        case "1":
                            questionIdAnswer[i][1] = "Hiç";
                            break;
                        case "2":
                            questionIdAnswer[i][1] = "Az";
                            break;
                        case "3":
                            questionIdAnswer[i][1] = "Çok";
                            break;
                        case "4":
                            questionIdAnswer[i][1] = "Pek Çok";
                            break;
                    }
                    uow.StudentQuestionnarieQuestionAnswerDataAccess
                    .Add(new StudentQuestionnarieQuestionAnswer()
                    {
                        Answer = new Answer() { AnswerName = questionIdAnswer[i][1] },
                        QuestionId = Convert.ToInt32(questionIdAnswer[i][0]),
                        QuestionnarieId = questionnarieId,
                        StudentId=studentId
                    });
                }
                uow.StudentPresentationQuestionnarieSessionDataAccess
                        .Add(new StudentPresentationQuestionnarieSession()
                        {
                            QuestionnarieId = questionnarieId,
                            StudentId = studentId,
                            SessionId = sessionId,
                            PresentationId = presentationId
                        });
                uow.SaveChanges();
            }
            catch (Exception ex)
            {
                return "Anket gönderimi sırasında bir hata oluştu";
            }
            return "Anket gönderimi başarılı";
        }
        public IActionResult PersonalQuestionnarieIndex()
        {
            return View();
        }
        
        public IActionResult ShowPresentationQuestionnarie()
        {
            List<Presentation> returnList = new List<Presentation>();
            var presentations = uow.PresentationDataAccess.GetAll().ToList();
            foreach (var presentation in presentations)
            {
                presentation.Sessions = uow.PresentationSession
                .GetAll()
                .Where(i => i.PresentationID == presentation.PresentationId)
                .ToList();

                foreach (var session in presentation.Sessions)
                {
                    session.Sessions = uow.SessionsDataAccess
                                        .GetAll()
                                        .Where(i => i.SessionId == session.SessionId)
                                        .Select(i => new Sessions()
                                        {
                                            StartTime = i.StartTime,
                                            EndTime = i.EndTime
                                        })
                                        .FirstOrDefault();
                }

                presentation.ClassPresentationsessions = uow.ClassPresentationsession
                    .GetAll()
                    .Where(i => i.PresentationId == presentation.PresentationId)
                    .ToList();

                foreach (var classes in presentation.ClassPresentationsessions)
                {
                    classes.Class = uow.ClassDataAccess
                        .GetAll()
                        .Where(i => i.ClassId == classes.ClassId)
                        .FirstOrDefault();
                }

                returnList.Add(presentation);
            }
            return View(returnList);
        }
        public IActionResult ShowQuestionnarieResult(int pid,int sid)
        {
            StudentPresentationSessionModel returnModel = new StudentPresentationSessionModel();
            returnModel.PresentationId = pid;
            returnModel.SessionId = sid;
            List<Student> registeredStudents = new List<Student>();

            var students = uow.studentPresentationsessionDataAccess
                .GetAll()
                .Where(i => i.PresentationId == pid && i.SessionId == sid)
                .ToList();

            foreach(var st in students)
            {
                st.Student = uow.StudentDataAccess.Get(st.StudentId);
                st.Student.Class = uow.ClassDataAccess.Get(st.Student.ClassId);
                registeredStudents.Add(uow.StudentDataAccess.Get(st.StudentId));
            }
            returnModel.Students = registeredStudents;
            return View(returnModel);
        }     
        public IActionResult ShowBeforeQuestionnarieResult(string studentSchoolId,int pid,int sid)
        {
            int qId = uow.QuestionnarieDataAccess
                .GetAll()
                .Where(i => i.QuestionnarieName == "Before")
                .FirstOrDefault()
                .QuestionnarieId;
            int studentId = uow.StudentDataAccess
                .GetAll()
                .Where(i => i.StudentSchoolId == studentSchoolId)
                .FirstOrDefault()
                .StudentId;
            var answers = uow.StudentQuestionnarieQuestionAnswerDataAccess
                .GetAll()
                .Where(i => i.StudentId == studentId && i.QuestionnarieId == qId);
            return View();
        }

    }
}