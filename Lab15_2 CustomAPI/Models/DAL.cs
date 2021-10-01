using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;

using MySql.Data.MySqlClient;


namespace Lab15_2_CustomAPI.Models
{
    public class DAL
    {

        public static MySqlConnection DB;
        public static int Movies() => DB.GetAll<Movie>().ToList().Count;

        public static Random r = new Random();

        //---------------------------------

        public static Movie GetMovie() => DB.Get<Movie>( r.Next (1, Movies() + 1));
        public static Movie GetMovie(int ID) => DB.Get<Movie>(ID);
        public static Movie GetMovie(string genre)
        {
            List<Movie> GenreSelected = DAL.GetAllMovies(genre);
            return GenreSelected[r.Next(0, GenreSelected.Count + 1)];
        }




        public static List<Movie> GetAllMovies() => DB.GetAll<Movie>().ToList();

        public static List<Movie> GetAllMovies(string genre)
        {
            var queryObj = new { Genre = genre };
            string query = "select * from movies where Genre = @Genre";
            return DB.Query<Movie>(query, queryObj).ToList();
        }

        public static List<Movie> FindMovies(string keyword)
        {


        }












    }
}
