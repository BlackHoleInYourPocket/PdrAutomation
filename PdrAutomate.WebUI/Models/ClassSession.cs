using PdrAutomate.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.Models
{
	public class ClassSession
	{
		public List<Sessions> Sessions { get; set; }
		public List<Class> Classes { get; set; }
	}
}
