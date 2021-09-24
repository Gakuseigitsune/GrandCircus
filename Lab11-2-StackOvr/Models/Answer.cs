using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Lab11_2_StackOvr.Models
{

    [Table("Answers")]
    public class Answer
    {
        [Key]
        public int ID { get; set; }
        public int QuestionID { get; set; }

        public string Username { get; set; }
        public string Detail { get; set; }
        public DateTime Posted { get; set; }
        public int Upvotes { get; set; }



    }
}
