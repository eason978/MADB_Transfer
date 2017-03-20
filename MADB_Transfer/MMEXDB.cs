using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MADB_Transfer
{
    class MMEXDB
    {
        public const string mStrDBRecordTblName = "CHECKINGACCOUNT_V1";
        private DataTable mDtDBRecordTbl = null;
        private const string mStrDBConn_PreFix = "Version=3;New=False;Compress=False;Data Source=";
        private const string mstrDBConn_PWD_PreFix = ";Jet OLEDB:Database Password=";
        private string mStrDBConnectionString = "";
        private SQLiteConnection myAccessConn = null;
        //private SQLiteCommand myAccessCmd;

        public DataTable mAllTables = null;

        public MMEXDB()
        {

        }
        public bool DB_Connection(string stDBPath, string pwd)
        {
            SQLiteCommand myAccessCmd;
            bool bRtn = false;
            String strTableName;
            mAllTables = new DataTable();
            if (File.Exists(stDBPath))
            {
                mStrDBConnectionString = mStrDBConn_PreFix + stDBPath;
                if (null != pwd && "" != pwd) mStrDBConnectionString += (mstrDBConn_PWD_PreFix + pwd);
                try
                {
                    myAccessConn = new SQLiteConnection(mStrDBConnectionString);
                    myAccessConn.Open();
                    myAccessCmd = myAccessConn.CreateCommand();//create command
                    myAccessCmd.CommandText = @"select * from sqlite_master where type = 'table'";
                    SQLiteDataReader dbreader = myAccessCmd.ExecuteReader();
                    mAllTables.Load(dbreader);
                    myAccessConn.Close();
                    foreach (DataRow dr in mAllTables.Rows)
                    {
#if true
                        strTableName = String.Format("{0}", dr["tbl_name"]);
                        //if (mStrDBRecordTblName == strTableName)
                        if (strTableName.Equals(mStrDBRecordTblName, StringComparison.OrdinalIgnoreCase))
                        {
                            bRtn = true;    //Find mStrDBRecordTblName in tables, this is MA database
                            mDtDBRecordTbl = new DataTable(mStrDBRecordTblName);
                            DB_ReadTable(mDtDBRecordTbl, mStrDBRecordTblName);
                            break;
                        }
                        //String tableName = String.Format("{0}", dr["TABLE_NAME"]);
                        //DataTable dt = new DataTable(tableName);
                        //ReadTable(dt, accessFile, tableName);
#endif
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Can not connect to " + stDBPath + "\r\n Error : " + ex.Message);
                    return false;
                }
                finally
                {
                    myAccessConn.Close();
                }

                if (true != bRtn)
                {
                    MessageBox.Show("Error: This is not MA database");
                }
            }
            else
            {
                MessageBox.Show("Error: File " + stDBPath + " does not exit");
            }
            return bRtn;
        }

        public DataTable DB_GetRecordTable()
        {
            if (null == mDtDBRecordTbl)
            {
                MessageBox.Show("Error: Please call MADB_Connection first");
            }
            return mDtDBRecordTbl;
        }

        public void DB_ReadTable(DataTable dt, string tableName)
        {
            string stQurey = String.Format("select * from [{0}]", tableName);
            DB_QueryTable(dt, stQurey);
        }

        public void DB_QueryTable(DataTable dt, string stQureyStr)
        {
#if true
            SQLiteCommand myAccessCmd;
            if (null == myAccessConn)
            {
                MessageBox.Show("Error: Please call DB_Connection first");
                return;
            }

            try
            {
                myAccessConn.Open();
                myAccessCmd = myAccessConn.CreateCommand();
                myAccessCmd.CommandText = stQureyStr;
                SQLiteDataReader dbReader = myAccessCmd.ExecuteReader();
                dt.Load(dbReader);
                dbReader.Close();
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(e.Message);
                MessageBox.Show("Error: Can not Read table \r\nQurey : " + stQureyStr + "\r\nError : " + ex.Message);
            }
            finally
            {
                myAccessConn.Close();
            }
#else
            DataTable myDataTable = new DataTable();
            myAccessConn.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter(SQLiteString, myAccessConn);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            myDataTable = ds.Tables[0];
            if (icn.State == ConnectionState.Open) icn.Close();
            return myDataTable;
#endif
        }
    }
}
