using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_kindergarten
{
    class Log
    {
        // Write errors to log-file.
        // Although this shit is causing most of the errors atm
        public static void Write(string strErr)
        {
            byte[] write = System.Text.Encoding.ASCII.GetBytes(strErr);
            fileStream.Write(write, 0, write.Length);
        }

        private static System.IO.FileStream fileStream = new System.IO.FileStream("/logs/errorlog.txt", System.IO.FileMode.OpenOrCreate);
    }
}
