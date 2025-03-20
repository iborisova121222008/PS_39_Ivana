using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Others
{

//    Delegates в C# представляват тип данни, който може да съхранява
//референции към методи с определен тип параметри и тип връщане.Те се
//използват за предаване на функционалност от един метод към друг метод,
//без да е необходимо да се знае точно кой метод ще бъде извикан.
    public delegate void ActionOnError(string error);
}
