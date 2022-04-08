using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MovieReviewApp.Models
{
    internal class Validation
    {
        public bool email_verification(string email)
        {
            string emailPattern = "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

            Match match = Regex.Match(email, emailPattern);

            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
