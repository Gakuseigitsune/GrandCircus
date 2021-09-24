using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab11_2_StackOvr.Models
{

    [Table("Questions")]
    public class Question
    {
        public static int TAG_MAX_L = 100;

        public string sStatus()
        {
            if (Status == 0) return "OPEN";
            else return "CLOSED";
        }

        [Key]
        public int ID { get; set; }

        public string Username { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime Posted { get; set; }
        public string Category { get; set; }
        public int Status { get; set; }

        public List<string> _Tags = new List<string>();
        public string Tags
        {
            get
            {
                StringBuilder alltags = new StringBuilder();

                foreach (string t in _Tags) alltags.Append($"{t} ");

                return alltags.ToString();
            }

            set
            {
                //string tagCapt = @"\""{1}(?<word>\w+)\""{1}";
                //Regex r = new Regex(tagCapt);

                int l = 0;
                foreach (string tag in _Tags) l += tag.Length;

                

                foreach (string newTag in value.Split(' ')) if (l + newTag.Length < TAG_MAX_L && !String.IsNullOrWhiteSpace(newTag) ) _Tags.Add(newTag);

            }
        }




    }
}
