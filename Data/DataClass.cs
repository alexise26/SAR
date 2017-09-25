using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace SAR.Data
{
    public class DataClass
    {
        //Variables globales
        #region
        static OracleConnection con;
        OracleCommand cmd;
        OracleParameter[] par;
        #endregion

        public static void ConString()
        {
            String ConString = "User Id = RESIDENTES; Password = residentes; Data source = localhost:1521 / xe;"; //DATA SOURCE = localhost:1521 / xe; USER ID = HR
            con = new OracleConnection();
            con.ConnectionString = ConString;
        } //Cadena de conexión

        public static void OpenCon()
        {
            con.Open();
        } //Abre la conexión

        public static void CloseCon()
        {
            if (con == null)
            {
                con.Close();
            }
        } //Cierra la conexión


        //=====================================================COMMAND============================================================ 

        public static OracleCommand Command(String sql)
        {
            try
            {
                ConString();
                OpenCon();
                OracleCommand cmd = new OracleCommand(sql, con);
                return cmd;
            }
            catch { return null; }

        }// regresa un OracleCommand.

        //=====================================================SELECT============================================================ 

        public static DataSet Select(OracleCommand cmd, String table)
        {

            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds, table);

            return ds;
        } //Inicia la sentencia Select.

        public static DataTable SelectDt(OracleCommand cmd, String table)
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            try
            {
                da.Fill(ds, table);
            }
            catch (Exception)
            {
            }
            dt = ds.Tables[table];
            return dt;
        } //Inicia la sentencia Select.

        //====================================================PARAMETERS=========================================================

        public static void Parameter(int i, String param, String type, String value, OracleCommand cmd, OracleParameter[] par)
        {

            try
            {
                switch (type)
                {
                    case "S":

                        par[i] = cmd.Parameters.Add(param, OracleDbType.Varchar2);
                        par[i].Direction = ParameterDirection.Input;
                        par[i].Value = value;

                        break;
                    case "N":

                        int ValueNum = int.Parse(value); //Convierte el valor a numérico
                        par[i] = cmd.Parameters.Add(param, OracleDbType.Int32);
                        par[i].Direction = ParameterDirection.Input;
                        par[i].Value = ValueNum;

                        break;
                    case "D":

                        DateTime ValueDate = DateTime.Parse(value); //Convierte el valor a fecha
                        par[i] = cmd.Parameters.Add(param, OracleDbType.Date);
                        par[i].Direction = ParameterDirection.Input;
                        par[i].Value = ValueDate;

                        break;
                    case "F":

                        Decimal ValueDeci = Decimal.Parse(value); //Convierte el valor a Decimal
                        par[i] = cmd.Parameters.Add(param, OracleDbType.Double);
                        par[i].Direction = ParameterDirection.Input;
                        par[i].Value = ValueDeci;

                        break;
                    case "T":

                        DateTime ValueTime = DateTime.Parse(value); //Convierte el valor a Decimal
                        par[i] = cmd.Parameters.Add(param, OracleDbType.Date);
                        par[i].Direction = ParameterDirection.Input;
                        par[i].Value = ValueTime;

                        break;
                }
            }
            catch { }

        } //Envía Parámetros a la sentencia

        //=====================================================EXECUTE===========================================================

        public static String Execute(String msg,OracleCommand cmd)
        {

            try
            {
                cmd.ExecuteNonQuery();
                return msg;
            }
            catch(Exception e)
            {
                return e.ToString();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    CloseCon();
                }
            }
        } //Ejecuta las sentencias.

        //======================================================COUNT============================================================ 

        public static int Count(OracleCommand cmd)
        {

            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());

            return count;
        } //Cuenta los registros de una tabla.

        //======================================================COUNT============================================================ 
        public static int MaxMin(String table, String file, String type)
        {

            String sql = "Select " + type + "(" + file + ") from " + table + "";
            OracleCommand cmd = DataClass.Command(sql);

            int value = 0;
            try
            {
                value = Convert.ToInt32(cmd.ExecuteScalar());
                return value;
            }
            catch { };
            return value;
        }

        //======================================================END============================================================== 
    }
}