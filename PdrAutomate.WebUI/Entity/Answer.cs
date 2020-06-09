using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
	public class Answer
	{
		public int AnswerId { get; set; }
		public string AnswerName { get; set; }
		public StudentQuestionnariePresentationSessionQuestionAnswer StudentQuestionnarieQuestionAnswers { get; set; }

	}
}
