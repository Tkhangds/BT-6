using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal_Management.Model
{
	internal class AnimalModel
	{
		public int id { get; set; }
		public string name { get; set; }
		public int quantity { get; set; }
		public int maximumMilkGiven { get; set; }
		public string speak {  get; set; }
	}
}
