using Keras.Models;
using PimaDoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimaDoctor.Utilities
{
    public static class Cache
    {
        public static User User { get; set; }
        public static BaseModel Model { get; set; }
        public static void Clear()
        {
            User = null;
            Model = null;
        }
    }
}
