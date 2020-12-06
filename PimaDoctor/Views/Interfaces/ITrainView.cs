using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimaDoctor.Views.Interfaces
{
    interface ITrainView
    {
        public Func<string,bool> RetrainNetwork { get; set; }
        public Func<string,string,bool> LoadNetwork { get; set; }
        public Func<string,string,bool> SaveNetwork { get; set; }
        public Func<bool> CheckForAdminRole { get; set; }
    }
}
