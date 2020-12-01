using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimaDoctor.Views.Interfaces
{
    interface ITrainView
    {
        public Func<bool> RetrainNetwork { get; set; }
        public Action<string> GetBackToMenu { get; set; }
    }
}
