using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Lab11_2_StackOvr.Models
{
    [Table ("Users")]
    public class Usr
    {
        [Key]
        public int UID { get; }

        public bool isAdmin { get; }
        public string Username { get; set; }

        public string email { get; set; }

    }
}
