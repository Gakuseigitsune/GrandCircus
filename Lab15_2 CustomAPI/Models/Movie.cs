using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper.Contrib.Extensions;

namespace Lab15_2_CustomAPI.Models
{
    public class Movie
    {

		[Table("Movies")]
		public class Product
		{
			[Key]
			public int ID { get; set; }

			public string Name { get; set; }
			public string Genre { get; set; }
			public string Director { get; set; }
			public string Rating { get; set; }
			public int Year { get; set; }

		}

	}
}
