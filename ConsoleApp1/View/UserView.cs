using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.ViewModel;

namespace ConsoleApp1.View
{
    public class UserView
    {
        private UserViewModel _viewModel;

        public UserView(UserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Display()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine("User:" + _viewModel.Name);
            Console.WriteLine("Role:" + _viewModel.Role);


        }

        public void DisplayError()
        {
            throw new Exception("ТЕКСТНА ГРЕШКАТА");
        }
    }

    
}
