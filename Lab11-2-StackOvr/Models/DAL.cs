using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Lab11_2_StackOvr.Models
{
    public class DAL
    {

        public static Usr sessionUser = null;

        public static bool isLogin()
        {
            return DAL.sessionUser != null;
        }

        public static MySqlConnection DB;
        //public static MySqlConnection DB = new MySqlConnection("Server=localhost;Database=lab11_2;Uid=root;Password=def456");

        //Testers
        public static Usr getAdmin()
        {
            return DB.Get<Usr>(1);
        }

        public static Usr getUsr()
        {
            return DB.Get<Usr>(2);
        }

        /*------------------------------------------------------------------------------------------------- */


        public static Usr getUsr(int UID)
        {

            return DB.Get<Usr>(UID);

        }
        

        public static Usr getUsr(string _Username)
        {
            if (String.IsNullOrWhiteSpace(_Username)) return null;

            var keyvalues = new { Username = _Username };

            string sql = "select * from Users where Username = @Username";

            return DB.Query<Usr>(sql,keyvalues).ToList()[0];

        }


        public static Question GetQuestion(int ID)
        {
            return DB.Get<Question>(ID);
        }

        public static List<Question> GetAllQs()
        {
            return DB.GetAll<Question>().ToList();
        }

        public static List<Question> GetAllQs(string _Username)
        {

            var keyvalues = new { Username = _Username  };

            string sql = "select * from Questions where Username = @Username";

            return DB.Query<Question>(sql, keyvalues).ToList();

        }

        public static List<Question> SearchAllQs(string _QTerm, string mode)
        {

            string sql = "";
            var keyvalues = new { searchterm = _QTerm };

            switch (mode)
            {
                case "t":
                    sql = "select * from Questions where Title like @searchterm";
                    break;

                case "tg":
                    sql = "select * from Questions where Tags like @searchterm";
                    break;
                case "d":
                    sql = "select * from Questions where Detail like @searchterm";
                    break;
                case "c":
                    sql = "select * from Questions where Category like @searchterm";
                    break;
                case "a":
                    sql = "select * from Questions where Category like @searchterm or Title like @searchterm or Tags like @searchterm or Detail like @searchterm";
                    break;
            }

            return DB.Query<Question>(sql, keyvalues).ToList();

        }

        public static Answer GetAnswer(int ID)
        {
            return DB.Get<Answer>(ID);
        }

        public static List<Answer> GetAllAnswers(int _QID)
        {
            var keyvalues = new { QID = _QID };

            string sql = "select * from Answers where QuestionID = @QID order by Upvotes desc";
            return DB.Query<Answer>(sql, keyvalues).ToList();
        }

        public static userQA GetAllByUser(string username)
        {
            userQA UserStuff = new userQA();

            var keyvalues = new { Username = username };

            string sql_1 = "select * from Answers where Username = @Username order by Upvotes desc";
            string sql_2 = "select * from Questions where Username = @Username order by Posted desc";

            UserStuff.UserAns = DB.Query<Answer>(sql_1, keyvalues).ToList();
            UserStuff.UserQs = DB.Query<Question>(sql_2, keyvalues).ToList();

            return UserStuff;


        }


        public static void PostQ(Question q)
        {
            DB.Insert(q);
        }

        public static void EditQ(Question q)
        {
            DB.Update<Question>(q);
            
        }
        public static void DeleteQ(Question q)
        {
            DB.Delete<Question>(q);

        }

        public static void PostA(Answer a)
        {
            DB.Insert(a);

        }

        public static void EditA(Answer a)
        {
            DB.Update<Answer>(a);
        }


        public static void DeleteA(Answer a)
        {
            DB.Delete<Answer>(a);
        }






    }
}
