using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdrAutomate.WebUI.DataAccess.Abstract;
using PdrAutomate.WebUI.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PdrAutomate.WebUI.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        IUnitOfWork uow;
        public StudentController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowPresentations(string studentSchoolId)
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

            foreach(var presentation in registeredPresentations)
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

        [HttpPost]
        public string RemovePresentation(string studentSchoolId, int presentationId, int sessionId)
        {
            var studentId = uow.StudentDataAccess
                   .GetAll()
                   .Where(i => i.StudentSchoolId == studentSchoolId)
                   .FirstOrDefault()
                   .StudentId;
            try
            {
                var deletedItem = new StudentPresentationsession()
                {
                    StudentId = studentId,
                    PresentationId = presentationId,
                    SessionId = sessionId
                };

                uow.studentPresentationsessionDataAccess.Delete(deletedItem);
                uow.SaveChanges();
                return "Silme işlemi başarılı";
            }
            catch (Exception)
            {
                return "Silme işlemi başarısız";
            }
        }
    }
}
