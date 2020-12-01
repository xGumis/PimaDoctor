using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimaDoctor.Views.Interfaces
{
    interface IAddUserView
    {
        public Func<string,string,string,bool> AdUser { get; set; }
        public Action<string> GoBackToMenu { get; set; }
    }
}
