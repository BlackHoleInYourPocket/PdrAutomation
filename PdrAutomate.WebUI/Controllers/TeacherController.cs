using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdrAutomate.WebUI.DataAccess.Abstract;
using PdrAutomate.WebUI.Entity;
using PdrAutomate.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using WordMorphology;
namespace PdrAutomate.WebUI.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        #region Otomasyon
        IUnitOfWork uow;
        public TeacherController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Session()
        {
            return View();
        }

        public string AddSession(DateTime startTime, DateTime endTime)
        {
            if (startTime == DateTime.MinValue || endTime == DateTime.MinValue)
            {
                return "Lütfen tüm boşlukları doldurun";
            }
            try
            {
                var isSessionAvaliable = uow.SessionsDataAccess
                    .GetAll()
                    .Where(i => i.StartTime == startTime && i.EndTime == endTime)
                    .FirstOrDefault();

                if (isSessionAvaliable != null) return "Zaten bu saatte bir oturum var";

                uow.SessionsDataAccess.Add(new Sessions()
                {
                    StartTime = startTime,
                    EndTime = endTime
                });
                uow.SaveChanges();
            }
            catch (Exception)
            {
                return "Oturum eklenemedi";
            }
            return "Oturum eklendi";
        }

        public string DeleteSession(int id)
        {
            try
            {
                var isSessionAvaliable = uow.SessionsDataAccess
                    .GetAll()
                    .Where(i => i.SessionId == id)
                    .FirstOrDefault();

                if (isSessionAvaliable == null) return "Böyle bir oturum bulunamadı";

                uow.SessionsDataAccess.Delete(isSessionAvaliable);
                uow.SaveChanges();
            }
            catch (Exception)
            {
                return "Oturum silinemedi";
            }
            return "Oturum silindi";
        }

        public string AddClassroom(string classNumber, string classWord, string classCapacity)
        {
            if (classCapacity == null)
            {
                return "Lütfen sınıf kapasitesini doldurun";
            }
            try
            {
                var className = String.Concat(classNumber, classWord);

                var classInfo = uow.ClassDataAccess
                .GetAll()
                .Where(i => i.ClassName == className)
                .FirstOrDefault();
                if (classInfo != null) return "Zaten bu sınıfı daha önceden eklediniz";

                uow.ClassDataAccess.Add(new Class()
                {
                    ClassName = className,
                    ClassCapacity = Int32.Parse(classCapacity)
                });

                uow.SaveChanges();
            }
            catch (Exception)
            {
                return "Sınıf eklenemedi";
            }

            return "Sınıf eklendi";
        }

        public string DeleteClassroom(int id)
        {
            try
            {
                var classInfo = uow.ClassDataAccess
                .GetAll()
                .Where(i => i.ClassId == id)
                .FirstOrDefault();
                if (classInfo == null) return "Böyle bir sınıf bulunamadı";

                uow.ClassDataAccess.Delete(classInfo);
                uow.SaveChanges();
            }
            catch (Exception)
            {
                return "Sınıf silinemedi";
            }

            return "Sınıf silindi";
        }

        public string DeleteStudent(int id)
        {
            try
            {
                uow.StudentDataAccess.Delete(new Student() { StudentId = id });
                uow.SaveChanges();
                return "Silindi";
            }
            catch (Exception)
            {
                return "Silinemedi";
            }

        }
        public IActionResult Presentation()
        {
            ClassSession returnModel = new ClassSession();
            returnModel.Sessions = uow.SessionsDataAccess
                .GetAll()
                .ToList();
            returnModel.Classes = uow.ClassDataAccess
                .GetAll()
                .ToList();
            return View(returnModel);
        }

        public string AddPresentation(string className, string sessions, string presentationName)
        {
            if (presentationName == null || sessions == null || className == null) return "Lütfen tüm bilgileri giriniz";

            try
            {
                var presentationNameIsRegistered = uow.PresentationDataAccess
                    .Find(i => i.PresentationName == presentationName)
                    .FirstOrDefault();

                if (presentationNameIsRegistered == null)
                {
                    uow.PresentationDataAccess.Add(new Presentation()
                    {
                        PresentationName = presentationName
                    });
                    uow.SaveChanges();
                }

                var classId = uow.ClassDataAccess
                    .Find(i => i.ClassName == className)
                    .FirstOrDefault()
                    .ClassId;

                var presentationId = uow.PresentationDataAccess
                    .Find(i => i.PresentationName == presentationName)
                    .FirstOrDefault()
                    .PresentationId;

                string[] session = sessions.Split('-');

                var sessionId = uow.SessionsDataAccess
                    .Find(i => i.StartTime == Convert.ToDateTime(session[0].Trim())
                    && i.EndTime == Convert.ToDateTime(session[1].Trim()))
                    .FirstOrDefault()
                    .SessionId;

                var presentationsessionvalid = uow.PresentationSession
                    .GetAll()
                    .Where(i => i.PresentationID == presentationId && i.SessionId == sessionId)
                    .FirstOrDefault();

                if (presentationsessionvalid == null)
                {
                    uow.PresentationSession
                        .Add(new PresentationSession()
                        {
                            PresentationID = presentationId,
                            SessionId = sessionId
                        });
                    uow.SaveChanges();
                }

                var isValid = uow.ClassPresentationsession
                    .GetAll()
                    .Where(i => i.PresentationId == presentationId && i.SessionId == sessionId && i.ClassId == classId)
                    .FirstOrDefault();

                if (isValid != null) return "Bu sınıf ve saatte böyle bir sunum var";

                isValid = uow.ClassPresentationsession
                    .GetAll()
                    .Where(i => i.SessionId == sessionId && i.ClassId == classId)
                    .FirstOrDefault();

                if (isValid != null) return "Seçilen saatte sınıfta başka bir sunum var";

                var newPresentation = new ClassPresentationsession()
                {
                    ClassId = classId,
                    SessionId = sessionId,
                    PresentationId = presentationId
                };

                uow.ClassPresentationsession.Add(newPresentation);
                uow.SaveChanges();
                return "Sunum eklendi";
            }
            catch (Exception ex)
            {
                return "Sunum eklenemedi";
            }
        }

        public IActionResult StudentList()
        {
            var allPresentation = uow.PresentationDataAccess
                .GetAll()
                .ToList();
            foreach (var pr in allPresentation)
            {
                pr.Sessions = uow.PresentationSession
                    .GetAll()
                    .Where(i => i.PresentationID == pr.PresentationId)
                    .ToList();

                foreach (var session in pr.Sessions)
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
                var sps = uow.studentPresentationsessionDataAccess
                    .GetAll()
                    .Where(i => i.PresentationId == pr.PresentationId)
                    .ToList();
                foreach (var _sps in sps)
                {
                    _sps.Sessions = uow.SessionsDataAccess
                        .GetAll()
                        .Where(i => i.SessionId == _sps.SessionId)
                        .FirstOrDefault();
                    _sps.Student = uow.StudentDataAccess
                        .GetAll()
                        .Where(i => i.StudentId == _sps.StudentId)
                        .FirstOrDefault();
                }
                pr.ClassPresentationsessions = uow.ClassPresentationsession
                        .GetAll()
                        .Where(i => i.PresentationId == pr.PresentationId)
                        .ToList();

                foreach (var classes in pr.ClassPresentationsessions)
                {
                    classes.Class = uow.ClassDataAccess
                        .GetAll()
                        .Where(i => i.ClassId == classes.ClassId)
                        .FirstOrDefault();
                }
            }

            return View(allPresentation);
        }

        public IActionResult SessionList()
        {
            return View(uow.SessionsDataAccess.GetAll().ToList());
        }

        public IActionResult ClassList()
        {
            var classes = uow.ClassDataAccess.GetAll().ToList();
            foreach (var _class in classes)
            {
                _class.Students = uow.StudentDataAccess
                    .GetAll()
                    .Where(i => i.ClassId == _class.ClassId)
                    .ToList();
            }
            return View(classes);
        }

        public string DeletePresentation(int pid, int sid)
        {
            try
            {
                uow.PresentationSession.Delete(new PresentationSession() { PresentationID = pid, SessionId = sid });
                uow.SaveChanges();
                return "Silindi";
            }
            catch (Exception)
            {
                return "Silinemedi";
            }
        }

        public IActionResult PresentationList()
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
        #endregion

        public IActionResult CreateBeierAnalysis(string studentSchoolId)
        {
            BeierResult returnModel = new BeierResult();
            BeierAnalysis analysis = new BeierAnalysis();
            returnModel.Valance = 0;
            returnModel.Dominanace = 0;
            returnModel.Arousal = 0;
            bool valance = true, dominance = true, arousal = true;
            List<Answer> answers = new List<Answer>();
            int studentId = uow.StudentDataAccess
                                .GetAll()
                                .Where(x => x.StudentSchoolId.Equals(studentSchoolId))
                                .FirstOrDefault()
                                .StudentId;
            returnModel.Student = uow.StudentDataAccess
                                .GetAll()
                                .Where(x => x.StudentId == studentId)
                                .FirstOrDefault();

            returnModel.Student.Class = uow.ClassDataAccess
                                .GetAll()
                                .Where(x => x.ClassId == returnModel.Student.ClassId)
                                .FirstOrDefault();

            var allData = uow.BeierStudentQuestionnarieQuestionAnswerDataAccess
                                .GetAll()
                                .Where(x => x.StudentId == studentId)
                                .ToList();

            foreach (var data in allData)
            {
                answers.Add(uow.AnswerDataAccess
                                .GetAll()
                                .Where(x => x.AnswerId == data.AnswerId)
                                .FirstOrDefault());
            }

            List<AnewDictionary> Anew = uow.AnewDictionaryDataAccess
                                .GetAll()
                                .ToList();

            foreach (var answer in answers)
            {
                String[] splittedAnswer = answer.AnswerName.Split(' ');
                for (int i = 0; i < splittedAnswer.Length; i++)
                {
                    bool firstMastar = false;
                    string ek = analysis.BeierEk(splittedAnswer[i]);
                    string kök = analysis.BeierKök(splittedAnswer[i]);

                    if (kök.Equals("")) continue;
                    if (ek.Equals("FIIL_KOK"))
                    {
                        kök = String.Concat(kök, "mak");
                        if (Anew.Exists(x => x.TurkishContent.Equals(kök)))
                        {
                            firstMastar = true;
                        }
                    }
                    if (ek.Equals("FIIL_KOK") && !firstMastar)
                    {
                        kök = String.Concat(kök, "mek");
                    }

                    if (Anew.Exists(x => x.TurkishContent.Equals(kök)))
                    {
                        AnewDictionary values = Anew.FirstOrDefault(x => x.TurkishContent.Equals(kök));
                        returnModel.Valance += values.Valance;
                        returnModel.Dominanace += values.Dominance;
                        returnModel.Arousal += values.Arousal;
                    }

                }
            }

            if (returnModel.Valance < 0) valance = false;
            if (returnModel.Arousal < 0) arousal = false;
            if (returnModel.Dominanace < 0) dominance = false;

            //  A +,V +,D + (En risksiz)
            //  A -, V +, D + (Risksiz)
            //  A +,V -,D + (Hayatından memnun değil ama kontrollü davranabiliyor)    
            //  A -, V -, D + (Depresif ama kontollü davranabiliyor)  
            //  A +,V +,D - (Hayatından memnun görünüyor ama kontollü davranamayabilir)  
            //  A -, V +,D - (Hayatından pek memnun değil, kontolünü kaybetme eğilimi var)
            //  A +,V -, D - (Şiddet eğilimli)
            //  A -, V -, D - (Kendine zarar verebilme eğilimli)
            if (arousal == true && valance == true && dominance == true) returnModel.Result = "En risksiz";
            else if (arousal == false && valance == true && dominance == true) returnModel.Result = "Risksiz";
            else if (arousal == true && valance == false && dominance == true) returnModel.Result = "Hayatından memnun değil ama kontrollü davranabiliyor";
            else if (arousal == false && valance == false && dominance == true) returnModel.Result = "Depresif ama kontollü davranabiliyor";
            else if (arousal == true && valance == true && dominance == false) returnModel.Result = "Hayatından memnun görünüyor ama kontollü davranamayabilir";
            else if (arousal == false && valance == true && dominance == false) returnModel.Result = "Hayatından pek memnun değil, kontolünü kaybetme eğilimi var";
            else if (arousal == true && valance == false && dominance == false) returnModel.Result = "Şiddet eğilimli";
            else if (arousal == false && valance == false && dominance == false) returnModel.Result = "Kendine zarar verebilme eğilimli";

            return View(returnModel);
        }
    }
}