using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAR.Data;
using Oracle.ManagedDataAccess.Client;


namespace SAR.Models
{
    public class SolicitudAg : Solicitud
    {
        protected String SOLICITUD_AGRICOLA_ID;
        protected String PRODUCTO;
        protected String TIPO_SOLICITUD;
        protected String PROPIA_EJIDAL;
        protected String RENTA;
        protected String TIPO_AG;
        protected String DANO_0_40;
        protected String DANO_41_70;
        protected String DANO_MAS_70;

        //Create SolicitudAg
        public SolicitudAg(string beneficiario, string folio, string ciclo, string capturo, string fecha_captura, string observaciones, string producto, string tipo_solicitud, string propia_ejidal, string renta, string tipo_ag, string dano_0_40, string dano_41_70, string dano_mas_70) : base(beneficiario, folio, ciclo, capturo, fecha_captura, observaciones)
        {   //base variables
            base.BENEFICIARIO = beneficiario;
            base.FOLIO = folio;
            base.CICLO = ciclo;
            base.CAPTURO = capturo;
            base.FECHA_CAPTURA = fecha_captura;
            base.OBSERVACIONES = observaciones;
            //this variables
            this.SOLICITUD_AGRICOLA_ID = (DataClass.MaxMin("SOLICITUD_AGRICOLA", "SOLICITUD_AGRICOLA_ID", "MAX") + 1).ToString();
            this.PRODUCTO = producto;
            this.TIPO_SOLICITUD = tipo_solicitud;
            this.PROPIA_EJIDAL = propia_ejidal;
            this.RENTA = renta;
            this.TIPO_AG = tipo_ag;
            this.DANO_0_40 = dano_0_40;
            this.DANO_41_70 = dano_41_70;
            this.DANO_MAS_70 = dano_mas_70;

        }
        //Save in Database
        public String Save()
        {
            String sql = "Insert into SOLICITUD_AGRICOLA (SOLICITUD_AGRICOLA_ID,BENEFICIARIO,FOLIO,PRODUCTO,TIPO_SOLICITUD,PROPIA_EJIDAL,RENTA,CICLO,TIPO_AGRICULTURA,DANO_0_40,DANO_41_70,DANO_MAS_70,CAPTURO,FECHA_CAPTURA,OBSERVACIONES)" + "VALUES(:id,:ben,:fol,:prod,:tiso,:prej,:rent,:ciclo,:tiag,:dan1,:dan2,:dan3,:cap,:fecha,:obs)";

            OracleCommand cmd = DataClass.Command(sql);
            OracleParameter[] par = new OracleParameter[15];

            DataClass.Parameter(0, "id", "N", this.SOLICITUD_AGRICOLA_ID, cmd, par);
            DataClass.Parameter(1, "ben", "N", base.BENEFICIARIO, cmd, par);
            DataClass.Parameter(2, "fol", "S", base.FOLIO, cmd, par);
            DataClass.Parameter(3, "prod", "N", this.PRODUCTO, cmd, par);
            DataClass.Parameter(4, "tiso", "N", this.TIPO_SOLICITUD, cmd, par);
            DataClass.Parameter(5, "prej", "F", this.PROPIA_EJIDAL, cmd, par);
            DataClass.Parameter(6, "rent", "F", this.RENTA, cmd, par);
            DataClass.Parameter(7, "ciclo", "N", base.CICLO, cmd, par);
            DataClass.Parameter(8, "tiag", "N", this.TIPO_AG, cmd, par);
            DataClass.Parameter(9, "dan1", "F", this.DANO_0_40, cmd, par);
            DataClass.Parameter(10, "dan2", "F", this.DANO_41_70, cmd, par);
            DataClass.Parameter(11, "dan3", "F", this.DANO_MAS_70, cmd, par);
            DataClass.Parameter(12, "cap", "N", base.CAPTURO, cmd, par);
            DataClass.Parameter(13, "fecha", "D", base.FECHA_CAPTURA, cmd, par);
            DataClass.Parameter(14, "obs", "S", base.OBSERVACIONES, cmd, par);


            return DataClass.Execute("Insertado con éxito", cmd);

        }
    }
}