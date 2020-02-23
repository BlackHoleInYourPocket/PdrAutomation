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
        IPresentationDataAccess presentationDataAccess;
        IPresentationClassDataAccess presentationClassDataAccess;
        IStudentPresentationDataAccess studentPresentationDataAccess;
        IStudentDataAccess studentDataAccess;
        public PresentationsController(IStudentDataAccess _studentDataAccess, IStudentPresentationDataAccess _studentPresentationDataAccess, IPresentationDataAccess _presentationDataAccess, IPresentationClassDataAccess _presentationClassDataAccess)
        {
            presentationDataAccess = _presentationDataAccess;
            presentationClassDataAccess = _presentationClassDataAccess;
            studentPresentationDataAccess = _studentPresentationDataAccess;
            studentDataAccess = _studentDataAccess;
        }
        public IActionResult Index()
        {
            return View(presentationDataAccess.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(presentationClassDataAccess
                .GetAll()
                .Where(i => i.PresentationId == id)
                //.Include(i => i.Class)
                //.ThenInclude(i => i.ClassCapacity)
                .Select(i => new PresentationClass()
                {
                    Presentation = i.Presentation,
                    Class = i.Class,
                    CurrentCapacity = i.CurrentCapacity
                }));
        }
        public IActionResult AddStudent(int presentationId, string studentSchoolId)
        {

            IEnumerable<Student> std = studentDataAccess
                 .GetAll()
                 .Where(i => i.StudentSchoolId == studentSchoolId)
                 .Select(i => new Student()
                 {
                     StudentId = i.StudentId
                 });
            int id = 0;
            foreach (var item in std)
            {
                id = item.StudentId;
            }
            IEnumerable<Student> prstd = studentPresentationDataAccess
                .GetAll()
             .Where(i => i.StudentId == id)
             .Select(i => new Student()
             {
                 StudentId = i.StudentId
             });
            if (prstd.Count() == 0 || prstd == null)
            {
                StudentPresentation newRecord = new StudentPresentation()
                {
                    PresentationId = presentationId,
                    StudentId = id
                };
                studentPresentationDataAccess.Add(newRecord);
                studentPresentationDataAccess.Save();
                ModelState.AddModelError("Error", "Kayıt Tamamlandı");
            }
            else
            {
                ModelState.AddModelError("Error", "Zaten Kayıtlısınız");
            }
            return RedirectToAction("Index", presentationDataAccess.GetAll());
        }
    }
}