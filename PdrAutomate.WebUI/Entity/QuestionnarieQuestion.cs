using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Entity
{
	public class QuestionnarieQuestion
	{
		public int QuestionnarieId { get; set; }
		public Questionnarie Questionnarie { get; set; }
		public int QuestionId { get; set; }
		public Question Question { get; set; }
	}
}
