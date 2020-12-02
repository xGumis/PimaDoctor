using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimaDoctor.Views.Interfaces
{
    interface IAddUserView
    {
        public Func<string,string,string,bool> AddUser { get; set; }
        public Action GoBackToMenu { get; set; }
    }
}
