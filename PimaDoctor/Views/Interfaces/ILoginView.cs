using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimaDoctor.Views.Interfaces
{
    interface ILoginView
    {
        public Func<string,string,bool> CheckCredentials { get; set; }
        public Action<string> Login { get; set; }
    }
}
