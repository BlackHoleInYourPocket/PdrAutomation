﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
	public class Question
	{
		public int QuestionId { get; set; }
		public string QuestionName { get; set; }
		public bool IsCheckbox { get; set; }
		public StudentQuestionnarieQuestionAnswer StudentQuestionnarieQuestionAnswers { get; set; }
	}
}
