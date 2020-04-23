using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
	public class StudentQuestionnarieQuestionAnswer
	{
		public int StudentId { get; set; }
		public Student Student { get; set; }
		public int QuestionnarieId { get; set; }
		public Questionnarie Questionnarie { get; set; }
		public int QuestionId { get; set; }
		public Question Question { get; set; }
		public int AnswerId { get; set; }
		public Answer Answer { get; set; }
	}
}
