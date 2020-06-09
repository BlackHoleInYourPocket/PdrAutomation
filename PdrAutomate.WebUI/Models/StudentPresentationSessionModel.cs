using PdrAutomate.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Models
{
	public class StudentPresentationSessionModel
	{
		public int PresentationId { get; set; }
		public int SessionId { get; set; }
		public List<Student> Students { get; set; }
	}
}
