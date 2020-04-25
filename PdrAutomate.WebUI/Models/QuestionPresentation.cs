using PdrAutomate.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Models
{
	public class QuestionPresentation
	{
		public int SessionId { get; set; }
		public int PresentationId { get; set; }
		public int QuestionnarieId { get; set; }
		public List<Question> Questions { get; set; }
	}
}
