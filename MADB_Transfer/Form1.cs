using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MADB_Transfer
{
    public partial class Form1 : Form
    {
        private MADB mMADB;
        public Form1()
        {
            InitializeComponent();
            mMADB = new MADB();
        }

        private void btn_xxxDBLoad_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DataTable dtTable;

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            if (sender == btn_SrcDBLoad)
                            {
                                textBox_SrcDBPath.Text = openFileDialog1.FileName;
                                if(mMADB.MADB_Connection(textBox_SrcDBPath.Text, "MA0502"))
                                {
                                    tabControl2.TabPages.Clear();
                                    TabPage tp = new TabPage(MADB.mStrMARecordTblName);
                                    DataGrid dg = new DataGrid();
                                    tabControl2.TabPages.Add(tp);
                                    tp.Controls.Add(dg);
                                    dg.DataSource = mMADB.MADB_GetRecordTable();
                                    dg.Dock = DockStyle.Fill;

                                    //for(int i = 0; i < mMADB.mAllTables.Rows.Count; i++)
                                    //{
                                    //    tabControl2.TabPages.Add(new TabPage(mMADB.mAllTables.Rows[i][2].ToString()));
                                    //}
                                }
                            }
                            else if (sender == btn_DstDBLoad)
                                textBox_DstDBPath.Text = openFileDialog1.FileName;
                            else
                                MessageBox.Show("Error, Open file error");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
