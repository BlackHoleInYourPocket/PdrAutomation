﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
	public class Questionnarie
	{
		public int QuestionnarieId { get; set; }
		public string QuestionnarieName { get; set; }
		public bool IsSentiment { get; set; }
		public List<Question> Questions { get; set; }
		public List<StudentQuestionnarieQuestionAnswer> StudentQuestionnarieQuestionAnswers { get; set; }


	}


}