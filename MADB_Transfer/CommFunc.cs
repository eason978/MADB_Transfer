using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MADB_Transfer
{
    class CommFunc
    {
        public static Stream Comm_OpenFileDialog(OpenFileDialog openFileDialog1)
        {
            Stream RtnOpenFilePath = null;
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((RtnOpenFilePath = openFileDialog1.OpenFile()) != null)
                    {
                        using (RtnOpenFilePath)
                        {
                            // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            return RtnOpenFilePath;
        }
    }
}
