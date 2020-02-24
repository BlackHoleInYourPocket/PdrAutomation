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
        IStudentDataAccess studentDataAccess;
        IStudentPresentationDataAccess studentPresentationDataAccess;
        IPresentationClassDataAccess presentationClassDataAccess;
        public StudentController(IPresentationClassDataAccess _presentationClassDataAccess, IStudentDataAccess _studentDataAccess, IStudentPresentationDataAccess _studentPresentationDataAccess)
        {
            studentDataAccess = _studentDataAccess;
            studentPresentationDataAccess = _studentPresentationDataAccess;
            presentationClassDataAccess = _presentationClassDataAccess;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowPresentations(string studentSchoolId)
        {
            var student = studentDataAccess.GetAll()
                .Where(x => x.StudentSchoolId == studentSchoolId)
                .Select(i => new Student()
                {
                    StudentId = i.StudentId
                }).ToList();

            var presentationIds = studentPresentationDataAccess.GetAll()
                .Where(x => x.StudentId == student[0].StudentId)
                .Select(i => new StudentPresentation()
                {
                    PresentationId = i.PresentationId
                }).ToList();

            List<PresentationClass> attendedPresentations = new List<PresentationClass>();

            foreach (var presentation in presentationIds)
            {
                var list = presentationClassDataAccess.GetAll()
                .Where(x => x.PresentationId == presentation.PresentationId)
                .Select(i => new PresentationClass()
                {
                    Class=i.Class,
                    ClassId = i.ClassId,
                    CurrentCapacity = i.CurrentCapacity,
                    Presentation = i.Presentation,
                    PresentationId = i.PresentationId,
                    Section = i.Section
                }).ToList();

                attendedPresentations.Add(list[0]);
            }

            return View(attendedPresentations);
        }
    }
}
