using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Others
{

//    Delegates в C# представляват тип данни, който може да съхранява
//референции към методи с определен тип параметри и тип връщане.Те се
//използват за предаване на функционалност от един метод към друг метод,
//без да е необходимо да се знае точно кой метод ще бъде извикан.
    public class Delegates
    {
        public static readonly ILogger logger = LoggerHelper.GetLogger("Hallo");

        //Първият метод принтира грешката посредством Logger-а, докато вторият
       // принтира директно в конзолата.
        public static void Log(string error)
        {
            logger.LogError(error);

        }

        public static void Log2(string error)
        {
            Console.WriteLine("- DELEGATES -");
            Console.WriteLine($"{error}");
            Console.WriteLine("- DELEGATES -");
        }
    }

}
