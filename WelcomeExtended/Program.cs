using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model;
using ConsoleApp1.Others;
using ConsoleApp1.ViewModel;
using ConsoleApp1.View;
using WelcomeExtended.Others;
using WelcomeExtended.Data;
using System.Security.Cryptography;
using WelcomeExtended.Helpers;



namespace WelcomeExtended
{
    public class Program
    {
        static void Main(string[] args)
        {
           // User u = new User(66, "Ivana B");
            try
            {
                //var user = new User
                //{
                //    Name = "Ivana B",
                //    Password = "password123",
                //    Role = UserRolesEnum.STUDENT

                //};
                //var viewModel = new UserViewModel(user);
                //var view = new UserView(viewModel);

                //view.Display();

                //try
                //{
                //    view.DisplayError();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(" Хваната грешка: " + ex.Message);
                //}
                UserData userData = new UserData();
                User studentUser = new User()
                {
                    Name = "student",
                    Password = "123",
                    Role = UserRolesEnum.STUDENT
                   
                };
                userData.AddUser(studentUser);


                var student2 = new User();
                student2.Name = "Student2";
                student2.Password = "123";
                student2.Role = UserRolesEnum.STUDENT;
                userData.AddUser(student2);

                var teacher = new User();
                teacher.Name = "Teacher";
                teacher.Password = "1234";
                teacher.Role = UserRolesEnum.PROFESSOR;
                userData.AddUser(teacher);

                var admin = new User();
                admin.Name = "Admin";
                admin.Password = "12345";
                admin.Role = UserRolesEnum.ADMIN;
                userData.AddUser(admin);

                //Console.WriteLine(userData.GetAllUsers().Count);


                Console.Write("Enter username: ");
                var searchedName = Console.ReadLine();

                Console.Write("Enter password: ");
                var searchedPassword = Console.ReadLine();

                var userExists = userData.ValidateCredentials(searchedName, searchedPassword);
                if (userExists)
                {
                    var user = userData.GetUser(searchedName, searchedPassword);
                    Console.WriteLine(user.ToStringHelper());

                }
                else
                {
                    throw new Exception("User not found");
                }

            }
            catch (Exception ex)
            {
                var log = new ActionOnError(Delegates.Log);
                log(ex.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case");
                Console.ReadLine();

            }
        }
    }
}
