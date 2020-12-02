using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimaDoctor.Views.Interfaces
{
    interface IMenu
    {
        public Action Logout { get; set; }
        public Action GoToTrain { get; set; }
        public Action GoToClassify { get; set; }
        public Action GoToUserAdd { get; set; }
        public Func<string> GetRole { get; set; }
    }
}
