﻿using System;
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
        public const string mStrDBRecordTblName = "tab記錄";
        private DataTable mDtDBRecordTbl = null;
        private const string mStrDBConn_PreFix = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        private const string mstrDBConn_PWD_PreFix = ";Jet OLEDB:Database Password=";
        private string mStrDBConnectionString = "";
        private OleDbConnection myAccessConn = null;

        public DataTable mAllTables = null;

        public MADB()
        {

        }

        public bool DB_Connection(string stDBPath, string pwd)
        {
            bool bRtn = false;
            String strTableName;
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
                    myAccessConn.Close();
                    foreach (DataRow dr in mAllTables.Rows)
                    {
                        if (dr["TABLE_TYPE"].ToString() == "VIEW" || dr["TABLE_TYPE"].ToString() == "TABLE")
                        {
                            strTableName = String.Format("{0}", dr["TABLE_NAME"]);
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
                            //allData.Tables.Add(dt);
                        }
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

                if(true != bRtn)
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
        public DataTable DB_GetRecordTable( )
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
            if (null == myAccessConn)
            {
                MessageBox.Show("Error: Please call MADB_Connection first");
                return;
            }

            try
            {
                myAccessConn.Open();
                OleDbCommand odCommand = myAccessConn.CreateCommand();
                odCommand.CommandText = stQureyStr;
                OleDbDataReader odrReader = odCommand.ExecuteReader();
                dt.Load(odrReader);
                odrReader.Close();
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
        }
    }
}
