using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Others;

namespace ConsoleApp1.Model
{


//Клас User, който представлява Модела на данните за всеки потребител.
    public class User
    {
     public string Name { get; set; }
     public string Password { get; set; }

     public UserRolesEnum Role { get; set; }

     public int Id { get; set; }

     public DateTime Expires { get; set; }



    }
}
