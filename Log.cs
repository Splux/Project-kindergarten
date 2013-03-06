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
            try
            {
                // Creates or open a file
                System.IO.FileStream fileStream = new System.IO.FileStream(@"./log.txt", System.IO.FileMode.Append);
                
                // Writes to file, closes and cleans up
                byte[] outbytes = Encoding.ASCII.GetBytes(strErr);
                
                fileStream.Write(outbytes, 0, outbytes.Length);
                fileStream.Close();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Log-class failed");
            }
        }

        
    }
}
