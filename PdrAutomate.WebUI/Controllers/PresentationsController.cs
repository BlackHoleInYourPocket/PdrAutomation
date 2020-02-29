using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdrAutomate.WebUI.DataAccess.Abstract;
using PdrAutomate.WebUI.Entity;

namespace PdrAutomate.WebUI.Controllers
{
    [Authorize]
    public class PresentationsController : Controller
    {
        IUnitOfWork uow;
        public PresentationsController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public IActionResult Index()
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

                returnList.Add(presentation);
            }

            return View(returnList);
        }

        public IActionResult Details(int presentationId, int sessionId)
        {
            var classInfo = uow.ClassPresentationsession.GetAll()
                .Where(i => i.PresentationId == presentationId)
                .Where(i => i.SessionId == sessionId)
                .FirstOrDefault();
            classInfo.Class = uow.ClassDataAccess.GetAll().Where(i => i.ClassId == classInfo.ClassId).FirstOrDefault();
            classInfo.Presentation = uow.PresentationDataAccess.GetAll().Where(i => i.PresentationId == classInfo.PresentationId).FirstOrDefault();
            classInfo.Sessions = uow.SessionsDataAccess.GetAll().Where(i => i.SessionId == classInfo.SessionId).FirstOrDefault();
            return View(classInfo);
        }
        public string AddStudent(int presentationId, string studentSchoolId, int sessionId)
        {
            var _studentId = uow.StudentDataAccess
                            .GetAll()
                            .Where(i => i.StudentSchoolId == studentSchoolId)
                            .FirstOrDefault().StudentId;
            var newStudent = new StudentPresentationsession()
            {
                PresentationId = presentationId,
                SessionId = sessionId,
                StudentId = _studentId
            };
            var isRegistered = uow.studentPresentationsessionDataAccess
                            .Find(i => i.StudentId == _studentId
                            && i.PresentationId == presentationId
                            && i.SessionId == sessionId)
                            .FirstOrDefault();
            if (isRegistered != null)
            {
                return "Zaten bu sunuma kayıtlısınız";
            }

            var isAvailableForSession = uow.studentPresentationsessionDataAccess
                            .GetAll()
                            .Where(i => i.StudentId == _studentId
                            && i.SessionId == sessionId)
                            .FirstOrDefault();

            if (isAvailableForSession != null)
            {
                return "Zaten bu saatte bir sunuma kayıtlısınız";
            }

            try
            {
                uow.studentPresentationsessionDataAccess
                                    .Add(newStudent);
                uow.SaveChanges();
                return "Kaydınız tamamlandı.";
            }
            catch (Exception)
            {
                return "Kayıt işleminiz yarıda kaldı. Lütfen tekrar deneyiniz.";
                throw;
            }
        }
    }
}