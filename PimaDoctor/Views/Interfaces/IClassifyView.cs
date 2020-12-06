using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimaDoctor.Views.Interfaces
{
    interface IClassifyView
    {
        public Func<int,int,int,int,int,double,double,int,double> ClassifyData { get; set; }
    }
}
