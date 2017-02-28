using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace MADB_Transfer
{
    class MADB
    {
        private const string mStrDBConn_PreFix = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        private const string mstrDBConn_PWD_PreFix = ";Jet OLEDB:Database Password=";
        private string mStrDBConnectionString = "";
        private OleDbConnection myAccessConn = null;

        public DataTable mAllTables = null;

        public MADB()
        {

        }

        public bool MADB_Connection(string stDBPath, string pwd)
        {
            bool bRtn = false;
            if (File.Exists(stDBPath))
            {
                mStrDBConnectionString = mStrDBConn_PreFix + stDBPath;
                if (null != pwd && "" != pwd) mStrDBConnectionString += (mstrDBConn_PWD_PreFix + pwd);
                try
                {
                    // We only want user tables, not system tables
                    string[] restrictions = new string[4];
                    restrictions[3] = "Table";

                    myAccessConn = new OleDbConnection(mStrDBConnectionString);
                    myAccessConn.Open();
                    mAllTables = myAccessConn.GetSchema("Tables", restrictions);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Can not connect to "+ stDBPath +"\r\n Error : " + ex.Message);
                    return false;
                }
                if (null != myAccessConn) bRtn = true;
            }
            else
            {
                MessageBox.Show("Error: File " + stDBPath + " does not exit");
            }
            return bRtn;
        }
    }
}
