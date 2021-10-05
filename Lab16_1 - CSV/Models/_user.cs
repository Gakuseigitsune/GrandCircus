using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace Lab16_1___CSV.Models
{
    public class _user
    {
        Dictionary<string, string> UserInfo = new Dictionary<string, string>();

        string _PW;

        public bool isInvalid
        {
            get
            {
                foreach (var keyVal in UserInfo)
                {
                    if (keyVal.Value == null) return true;
                }
                return _PW == null;
            }
            
        }

        public string FirstName
        {
            get => UserInfo["f_Name"];
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2) UserInfo.Add("f_Name",null);
                UserInfo.Add("f_Name", value);
            }
        }

        public string LastName
        {
            get => UserInfo["l_Name"];
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2) UserInfo.Add("l_Name", null);
                UserInfo.Add("l_Name", value);
            }
        }

        public string Email
        {
            get => UserInfo["email"];
            set
            {
                string emailPattern = @"(\w+\u0040{1}\w+\.{1}\w+)";
                Regex emailCapt = new Regex(emailPattern);
                MatchCollection capture = emailCapt.Matches(value);

                if (capture.Count == 0 || String.IsNullOrWhiteSpace(value)) UserInfo.Add("email", null);
                else UserInfo.Add("email", value);

            }
        }

        public string Password
        {
            get => _PW;
            set
            {
                string PWValid = @"(?=.*\u0040+)(?=.*\p{Lu}+)(?=.*\p{Ll}+)(?=.*\p{Nd}+).*";
                Regex PWCheck = new Regex(PWValid);
                MatchCollection capture = PWCheck.Matches(value);

                if (capture.Count == 0 || value.Length < 8) _PW = null;
                else _PW = value;
            }
        }





    }
}
