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
                System.IO.BinaryWriter fileStream = new System.IO.BinaryWriter(System.IO.File.OpenWrite(@"./log.txt"));
                
                // Writes to file, closes and cleans up
                fileStream.Write(strErr);
                fileStream.Close();
                fileStream.Dispose();
                fileStream = null;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Log-class failed");
            }
        }

        
    }
}
