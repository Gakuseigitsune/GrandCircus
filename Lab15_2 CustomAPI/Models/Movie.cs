using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper.Contrib.Extensions;

namespace Lab15_2_CustomAPI.Models
{
	[Table("Movies")]
	public class Movie
    {
		[ExplicitKey]
		public int ID { get; set; }

		public string Name { get; set; }
		public string Genre { get; set; }
		public string Director { get; set; }
		public string Rating { get; set; }
		public int Year { get; set; }

	}

	[Table ("Genre")]
	public class Genre
    {
		[Key]
		public string Name { get; set; }

    }
}
