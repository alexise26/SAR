using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using SAR.Data;

namespace SAR.Models
{
    public class Ciclo
    {
        protected String CICLO_ID;
        protected String CICLO_DES;
        protected String ESTATUS;
        protected String FECHA_APERTURA;
        protected String FECHA_CIERRE;
        protected String CICLO_CVE;

        public Ciclo(string ciclo_des, string estatus, string ciclo_cve, string fecha_apertura, string fecha_cierre) {
            this.CICLO_ID = (DataClass.MaxMin("CICLOS", "CICLO_ID", "MAX") + 1).ToString();
            this.CICLO_DES = ciclo_des;
            this.ESTATUS = estatus;
            this.FECHA_APERTURA = fecha_apertura;
            this.FECHA_CIERRE = fecha_cierre;
            this.CICLO_CVE = ciclo_cve;
        }


        //Save Producto in Database
        public String Save()
        {
            String sql = "Insert into CICLOS (CICLO_ID,CICLO_DES,ESTATUS,FECHA_APERTURA,FECHA_CIERRE,CICLO_CVE)" + "VALUES(:ciclo_id,:ciclo_des,:estatus,:fecha_apertura,:fecha_cierre,:ciclo_cve)";

            OracleCommand cmd = DataClass.Command(sql);
            OracleParameter[] par = new OracleParameter[6];

            DataClass.Parameter(0, "ciclo_id", "N", this.CICLO_ID, cmd, par);
            DataClass.Parameter(1, "ciclo_des", "S", this.CICLO_DES, cmd, par);
            DataClass.Parameter(2, "estatus", "N", this.ESTATUS, cmd, par);
            DataClass.Parameter(3, "fecha_apertura", "D", this.FECHA_APERTURA, cmd, par);
            DataClass.Parameter(4, "fecha_cierre", "D", this.FECHA_CIERRE, cmd, par);
            DataClass.Parameter(5, "ciclo_cve", "S", this.CICLO_CVE, cmd, par);


            return DataClass.Execute("Insertado con éxito", cmd);

        }


    }
}