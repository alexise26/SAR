using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using SAR.Data;

namespace SAR.Models
{
    public class Beneficiario
    {
        private String BENEFICIARIO_ID;
        private String CURP;
        private String UPP;
        private String MUNICIPIO;
        private String LOCALIDAD;
        private String PATERNO;
        private String MATERNO;
        private String NOMBRE;
        private String GENERO;
        private String FECHA_NAC;
        private String EDO_NAC;
        private String DOMICILIO;
        private String EDO_CIVIL;
        private String OCUPACION;
        private String TELEFONO;
        private String CAPTURO;
        private String OBSERVACION;

        //Create Beneficiario
        public Beneficiario( string curp, string upp, string municipio, string localidad, string paterno, string materno, string nombre, string genero, string fecha_nac, string edo_nac, string domicilio, string edo_civil, string ocupacion, string telefono, string capturo, string observacion) {

            this.BENEFICIARIO_ID = (DataClass.MaxMin("BENEFICIARIOS", "BENEFICIARIO_ID", "MAX") + 1).ToString();
            this.CURP = curp;
            this.UPP = upp;
            this.MUNICIPIO = municipio;
            this.LOCALIDAD = localidad;
            this.PATERNO = paterno;
            this.MATERNO = materno;
            this.NOMBRE = nombre;
            this.GENERO = genero;
            this.FECHA_NAC = fecha_nac;
            this.EDO_NAC = edo_nac;
            this.DOMICILIO = domicilio;
            this.EDO_CIVIL = edo_civil;
            this.OCUPACION = ocupacion;
            this.TELEFONO = telefono;
            this.CAPTURO = capturo;
            this.OBSERVACION = observacion;
        }

        //Save Beneficiario in Database
        public String Save() {
            String sql = "Insert into BENEFICIARIOS (BENEFICIARIO_ID,CURP,UPP,MUNICIPIO,LOCALIDAD,PATERNO,MATERNO,NOMBRE,GENERO,FECHA_NAC,EDO_NAC,DOMICILIO,EDO_CIVIL,OCUPACION,TELEFONO,CAPTURO,OBSERVACION)" + "VALUES(:id, :curp, :upp, :mun, :loc, :pat, :mat, :nom, :gen, :fe_nac, :ed_nac, :dom, :ed_civ, :ocu, :tel, :cap, :obs)";

            OracleCommand cmd = DataClass.Command(sql);
            OracleParameter[] par = new OracleParameter[17];

            DataClass.Parameter(0, "id", "N", this.BENEFICIARIO_ID, cmd, par);
            DataClass.Parameter(1, "curp", "S", this.CURP, cmd, par);
            DataClass.Parameter(2, "upp", "S", this.UPP, cmd, par);
            DataClass.Parameter(3, "mun", "N", this.MUNICIPIO, cmd, par);
            DataClass.Parameter(4, "loc", "S", this.LOCALIDAD, cmd, par);
            DataClass.Parameter(5, "pat", "S", this.PATERNO, cmd, par);
            DataClass.Parameter(6, "mat", "S", this.MATERNO, cmd, par);
            DataClass.Parameter(7, "nom", "S", this.NOMBRE, cmd, par);
            DataClass.Parameter(8, "gen", "S", this.GENERO, cmd, par);
            DataClass.Parameter(9, "fe_nac", "D", this.FECHA_NAC, cmd, par);
            DataClass.Parameter(10, "ed_nac", "S", this.EDO_NAC, cmd, par);
            DataClass.Parameter(11, "dom", "S", this.DOMICILIO, cmd, par);
            DataClass.Parameter(12, "ed_civ", "S", this.EDO_CIVIL, cmd, par);
            DataClass.Parameter(13, "ocu", "S", this.OCUPACION, cmd, par);
            DataClass.Parameter(14, "tel", "S", this.TELEFONO, cmd, par);
            DataClass.Parameter(15, "cap", "N", this.CAPTURO, cmd, par);
            DataClass.Parameter(16, "obs", "S", this.OBSERVACION, cmd, par);

            return DataClass.Execute("Insertado con éxito",cmd);

        }
    }
}