using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Others;
using ConsoleApp1.ViewModel;
using ConsoleApp1.View;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Стартиране на ConsoleApp1...");

                var user = new User
                {
                    Name = "Ivana",
                    Password = "password123",
                    Role = UserRolesEnum.STUDENT
                };

                var viewModel = new UserViewModel(user);
                var view = new UserView(viewModel);

                view.Display();
                try
                {
                    view.DisplayError();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Хваната грешка: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ГРЕШКА В ConsoleApp1: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("ConsoleApp1 приключи.");
            }
        }

    }
}

