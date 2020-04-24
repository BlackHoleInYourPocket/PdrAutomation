using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
	public class StudentPresentationQuestionnarieSession
	{
		public int StudentId { get; set; }
		public Student Student { get; set; }
		public int PresentationId { get; set; }
		public Presentation Presentation { get; set; }
		public int QuestionnarieId { get; set; }
		public Questionnarie Questionnarie { get; set; }
		public int SessionId { get; set; }
		public Sessions Session { get; set; }
	}
}
