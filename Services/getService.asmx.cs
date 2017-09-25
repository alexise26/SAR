using System;
using SAR.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Newtonsoft.Json;

namespace SAR.Services
{
    /// <summary>
    /// Descripción breve de getService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class getService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        
        [WebMethod]
        //Get all "Ciclos"  by http.get
        public void getCiclos()
        {
            String sql = "Select * from VW_CICLOS";
            String tabla = "VW_CICLOS";

            OracleCommand cmd = DataClass.Command(sql);
            DataClass.Execute("", cmd);

            DataTable dt = DataClass.SelectDt(cmd, tabla);

            string jsonString = JsonConvert.SerializeObject(dt);
            Context.Response.Write(jsonString);
        }
        
        [WebMethod]
        //Get all "Estados"  by http.get
        public void getEstados()
        {
            String sql = "Select * from ESTADOS";
            String tabla = "ESTADOS";

            OracleCommand cmd = DataClass.Command(sql);
            DataClass.Execute("", cmd);

            DataTable dt = DataClass.SelectDt(cmd, tabla);

            string jsonString = JsonConvert.SerializeObject(dt);
            Context.Response.Write(jsonString);

        }

        
        [WebMethod]
        //Get all "Municipios"  by http.get
        public void getMunicipios()
        {
            String sql = "Select * from MUNICIPIOS";
            String tabla = "MUNICIPIOS";

            OracleCommand cmd = DataClass.Command(sql);
            DataClass.Execute("", cmd);

            DataTable dt = DataClass.SelectDt(cmd, tabla);

            string jsonString = JsonConvert.SerializeObject(dt);
            Context.Response.Write(jsonString);

        }
        [WebMethod]
        //Get  "Localidades" that belong to selected "Municipio"  by http.get
        public void getLocalidades(int mun_id)
        {
            String municipio;
            if (mun_id < 10)
            {
                municipio = "00" + mun_id.ToString();
            }
            else { 
                municipio = "0" + mun_id.ToString();
            }
            String sql = "Select CVE_LOCALIDAD,LOCALIDAD,CVE_MPIO  from LOCALIDAD WHERE CVE_ENTIDAD LIKE '08' AND CVE_LOCALIDAD IS NOT NULL AND CVE_MPIO IS NOT NULL AND CVE_MPIO LIKE '" + municipio + "'";
            String tabla = "LOCALIDAD";

            OracleCommand cmd = DataClass.Command(sql);
            DataClass.Execute("", cmd);

            DataTable dt = DataClass.SelectDt(cmd, tabla);

            string jsonString = JsonConvert.SerializeObject(dt);
            Context.Response.Write(jsonString);
        }
        [WebMethod]
        //Get all "Tipos Agricultura"  by http.get
        public void getTipoAgricultura()
        {
            String sql = "Select * from TIPO_AGRICULTURA";
            String tabla = "TIPO_AGRICULTURA";

            OracleCommand cmd = DataClass.Command(sql);
            DataClass.Execute("", cmd);

            DataTable dt = DataClass.SelectDt(cmd, tabla);

            string jsonString = JsonConvert.SerializeObject(dt);
            Context.Response.Write(jsonString);
        }
        
        [WebMethod]
        //Get all "Productos"  by http.get
        public void getProductos()
        {
            String sql = "Select * from VW_PRODUCTOS";
            String tabla = "VW_PRODUCTOS";

            OracleCommand cmd = DataClass.Command(sql);
            DataClass.Execute("", cmd);

            DataTable dt = DataClass.SelectDt(cmd, tabla);

            string jsonString = JsonConvert.SerializeObject(dt);
            Context.Response.Write(jsonString);
        }
        [WebMethod]
        //Get all "Beneficiarios"  by http.get
        public void getBeneficiarios()
        {
            String sql = "Select * from VW_BENEFICIARIOS";
            String tabla = "VW_BENEFICIARIOS";

            OracleCommand cmd = DataClass.Command(sql);
            DataClass.Execute("", cmd);

            DataTable dt = DataClass.SelectDt(cmd, tabla);

            string jsonString = JsonConvert.SerializeObject(dt);
            Context.Response.Write(jsonString);
        }
        
        [WebMethod]
        //Get all "Tipos Solicitud"  by http.get
        public void getTipoSolicitud()
        {
            String sql = "Select * from TIPO_SOLICITUD";
            String tabla = "TIPO_SOLICITUD";

            OracleCommand cmd = DataClass.Command(sql);
            DataClass.Execute("", cmd);

            DataTable dt = DataClass.SelectDt(cmd, tabla);

            string jsonString = JsonConvert.SerializeObject(dt);
            Context.Response.Write(jsonString);
        }
       
    }
}
