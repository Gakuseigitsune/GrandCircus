using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab15_2_CustomAPI.Models;

namespace Lab15_2_CustomAPI.Controllers
{

	[Route("api/genre")]
	[ApiController]
	public class GenreController : ControllerBase
    {
		[HttpGet]
		public List<Genre> GetAllGenre() => DAL.GetAllGenre();
    }

	[Route("api/movies")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		[HttpGet]
		public List<Movie> GetAllMovies ()
		{
			return DAL.GetAllMovies();
		}

		[HttpGet("genre")]
		public List<Movie> GetAllMovies(string genre)
		{
			return DAL.GetAllMovies(genre);
		}


		[HttpGet("name/s")]
		public Movie GetMovie(string name)
		{
			return DAL.GetThisMovie(name);
		}

		[HttpGet("name")]
		public List<Movie> GetMovies(string name)
		{
			return DAL.GetTheseMovies(name);
		}

		[HttpGet("{id}")]
		public Movie GetMovie(int id)
		{
			return DAL.GetMovie(id);
		}

		[HttpGet("search")]
		public List<Movie> FindMovies(string keyword)
		{
			return DAL.GetMovies(keyword);
		}

		[HttpGet("any")]
		public Movie GetRandMovie() => DAL.GetMovie();

		[HttpGet("any/c")]
		public List<Movie> GetRandMovie(int count)
		{
			List<Movie> picks = new List<Movie>();

			for (int i = 0; i < count; i++)
            {
				picks.Add(DAL.GetMovie());

            }

			return picks;
		}

		[HttpGet("any/genre")]
		public Movie GetRandMovie(string genre) => DAL.GetMovie(genre);
	}




}
