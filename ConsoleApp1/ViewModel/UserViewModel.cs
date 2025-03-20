using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model;
using ConsoleApp1.Others;

namespace ConsoleApp1.ViewModel
{

    //Клас UserViewModel, който отговаря за прехвърлянето на данните от Model-
     //а, към View-то.
    public class UserViewModel
    {
        private User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }

        public string Name
        {
            get { return _user.Name; }
            set { _user.Name = value; }
        }

        public string Password
        {
            get => _user.Password;

            set { _user.Password = value; }

        }

        public UserRolesEnum Role
        {
            get { return _user.Role; }
            set { _user.Role = value; }
        }
    }
}
