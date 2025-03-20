using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {

        //По този начин правим Extension метод на класа User.


       // Това често се
       //използва за да пренапишем стандартни методи включени в.NET.
        public static string ToStringHelper(this User user)
        {
            return $"{user.Name}: {user.Role}";
        }
    }
}
