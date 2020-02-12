using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraryreleve.Service
{
    public class superglobale
    {
        //global PathFile
        private static string v_GlobalPath = "";
        public static string GlobalPath
        {
            get { return v_GlobalPath; }
            set { v_GlobalPath = value; }
        }
    }
}
