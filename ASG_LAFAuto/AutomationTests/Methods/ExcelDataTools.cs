using System.Configuration;
using System.Data.OleDb;
//using lcpi.data.oledb;
using System.Linq;
using Dapper;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Windows.Forms;

namespace AutomationTests.TestDataAccess
{
    class ExcelDataTools
    {
        public static OleDbConnection GetTestDataFileConnection(string filepath)
        {
            
            var conString = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", filepath);

            return new OleDbConnection(conString);
        }

        internal static void PopulateWorkSheetCombo(OleDbConnection excelConnection,ComboBox cmbo)
        {
            
            OleDbDataReader ODR = null;
            //create connection
            

            try
            {

                cmbo.Items.Clear();
                //open connection
                excelConnection.Open();

                //create command    
                //OleDbCommand OCMD = new OleDbCommand();
                //OCMD.CommandText = "SELECT ID, DESCRIPTION FROM TABLE";
                //execute command
                //ODR = OCMD.ExecuteReader();

                //load datareader to datatable       
                DataTable DT = new DataTable();

                DT = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                excelConnection.Close();
                String[] excelSheets = new String[DT.Rows.Count];
                int i = 0;



                foreach (DataRow row in DT.Rows)
                {
                    if (!(row["TABLE_NAME"].ToString().Contains("xln")));
                    {

                    
                        if (!cmbo.Items.Contains(row))
                    {
                            cmbo.Items.Add(row["TABLE_NAME"].ToString());
                            //.Replace("$",""));
                    }
                   

                    i++;
                    }
                }

               
            }
            /**

            DT.Load(ODR);

            //attach datatable to combobox
            cmbo.DisplayMember = "DESCRIPTION";
            cmbo.ValueMember = "ID";
            cmbo.DataSource = DT;

            //close connection
            OCON.Close();
        }
        **/
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
               
            }
            
        }


        /**
        public static TestSettingsObject GetTestRunSettings()
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [TestRunSettings$]");
                List<TestSettingsObject> testSetting = connection.Query<TestSettingsObject>(query).ToList();
                connection.Close();
                return testSetting.First();
            }
        }
    **/
        internal static List<TestDataObject> GetTestData(OleDbConnection excelConnection,string tabName)
        {
            
                excelConnection.Open();
                var query = string.Format("select * from ["+tabName+"] where ExecutionMode = 'RUN'");
                var value = excelConnection.Query<TestDataObject>(query).ToList();
                excelConnection.Close();
                return value;
            
        }

        public static List<EnvironmentSettingsObject> GetEnvironmentSettings(string environment, OleDbConnection excelConnection)
        {

                excelConnection.Open();
                var query = string.Format("select * from [Environments$] where Environment = '{0}'",environment);
                List<EnvironmentSettingsObject> environmentSettings = excelConnection.Query<EnvironmentSettingsObject>(query).ToList();
                excelConnection.Close();
                return environmentSettings;
            
        }

        

        public static List<ApplicationDataObject> GetApplicationData(string environment, OleDbConnection excelConnection)
        {

            excelConnection.Open();
                var query = string.Format("select * from [Applications$]");
                var applicationData = excelConnection.Query<ApplicationDataObject>(query).ToList();
            excelConnection.Close();
                return applicationData;
            
        }


        /**
        public static List<TestData> GetTestData()
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [TestCases$] where ExecutionMode = 'RUN'");  
        var value = connection.Query<TestData>(query).ToList();
                connection.Close();
                return value;
            }
        }
    **/


            /**
        public static List<TestData> GetTestData(string tabName, string filter, string value)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from ["+tabName+"$] where "+filter+"='"+value+"' and control = '1'");
                var list = connection.Query<TestData>(query).ToList();
                connection.Close();
                return list;
            }
        }
    **/
        public static DataTable GetWorkSheetNames(OleDbConnection excelConnection)
        {

            excelConnection.Open();

                DataTable schemaTable = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,null);
            excelConnection.Close();
                return schemaTable;

                
            
        }


        public static void WriteToCell(int row, string column, string value, string tab, OleDbConnection excelConnection)
        {



            excelConnection.Open();
                string query = "Update [" + tab + "] set " + column + " = '" + value + "' where id=" + row + " and ExecutionMode = 'RUN'";
                Debug.WriteLine("query=" + query);

            excelConnection.Query(query);



            excelConnection.Close();
           


            
        }

        internal static void PopulateEnvironmentCombo(OleDbConnection excelConnection, ComboBox comboEnvironment)
        {
            throw new NotImplementedException();
        }

        internal static List<EnvironmentSettingsObject> GetEnvironments(OleDbConnection excelConnection, ComboBox comboEnvironment)
        {
            excelConnection.Open();
            var query = "select environment from [Environments$]";
            List<EnvironmentSettingsObject> environmentSettings = excelConnection.Query<EnvironmentSettingsObject>(query).ToList();
            excelConnection.Close();
            return environmentSettings;
        }
    }
}
