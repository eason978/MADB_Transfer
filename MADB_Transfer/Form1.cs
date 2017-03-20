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
        private MMEXDB mMMEXDB;
        public Form1()
        {
            InitializeComponent();
            tabControl2.TabPages.Clear();
            mMADB = new MADB();
            mMMEXDB = new MMEXDB();
        }

        private void btn_xxxDBLoad_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

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
                                if(mMADB.DB_Connection(textBox_SrcDBPath.Text, "MA0502"))
                                {
                                    //tabControl2.TabPages.Clear();
                                    TabPage tp = new TabPage(MADB.mStrDBRecordTblName);
                                    DataGrid dg = new DataGrid();
                                    tabControl2.TabPages.Add(tp);
                                    tp.Controls.Add(dg);
                                    string stQ = @"select r.目的帳戶, r.交易明細 from tab記錄 r group by r.目的帳戶, r.交易明細";
                                    DataTable dt = new DataTable();
                                    mMADB.DB_QueryTable(dt, stQ);
                                    dg.DataSource = dt;
                                    dg.Dock = DockStyle.Fill;

                                    //for(int i = 0; i < mMADB.mAllTables.Rows.Count; i++)
                                    //{
                                    //    tabControl2.TabPages.Add(new TabPage(mMADB.mAllTables.Rows[i][2].ToString()));
                                    //}
                                }
                            }
                            else if (sender == btn_DstDBLoad)
                            {
                                textBox_DstDBPath.Text = openFileDialog1.FileName;
                                if (mMMEXDB.DB_Connection(textBox_DstDBPath.Text, null))
                                {
                                    //tabControl2.TabPages.Clear();
                                    TabPage tp = new TabPage(MMEXDB.mStrDBRecordTblName);
                                    DataGrid dg = new DataGrid();
                                    tabControl2.TabPages.Add(tp);
                                    tp.Controls.Add(dg);
                                    dg.DataSource = mMMEXDB.DB_GetRecordTable();
                                    dg.Dock = DockStyle.Fill;

                                    //for(int i = 0; i < mMADB.mAllTables.Rows.Count; i++)
                                    //{
                                    //    tabControl2.TabPages.Add(new TabPage(mMADB.mAllTables.Rows[i][2].ToString()));
                                    //}
                                }
                            }
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
