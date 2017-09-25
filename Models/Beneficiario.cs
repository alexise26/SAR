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

        public Beneficiario( string curp, string upp, string municipio, string localidad, string paterno, string materno, string nombre, string genero, string fecha_nac, string edo_nac, string domicilio, string edo_civil, string ocupacion, string telefono, string capturo, string observacion) {

            BENEFICIARIO_ID = (DataClass.MaxMin("BENEFICIARIOS", "BENEFICIARIO_ID", "MAX") + 1).ToString();
            CURP = curp;
            UPP = upp;
            MUNICIPIO = municipio;
            LOCALIDAD = localidad;
            PATERNO = paterno;
            MATERNO = materno;
            NOMBRE = nombre;
            GENERO = genero;
            FECHA_NAC = fecha_nac;
            EDO_NAC = edo_nac;
            DOMICILIO = domicilio;
            EDO_CIVIL = edo_civil;
            OCUPACION = ocupacion;
            TELEFONO = telefono;
            CAPTURO = capturo;
            OBSERVACION = observacion;
        }

        public String Save() {
            String sql = "Insert into BENEFICIARIOS (BENEFICIARIO_ID,CURP,UPP,MUNICIPIO,LOCALIDAD,PATERNO,MATERNO,NOMBRE,GENERO,FECHA_NAC,EDO_NAC,DOMICILIO,EDO_CIVIL,OCUPACION,TELEFONO,CAPTURO,OBSERVACION)" + "VALUES(:id, :curp, :upp, :mun, :loc, :pat, :mat, :nom, :gen, :fe_nac, :ed_nac, :dom, :ed_civ, :ocu, :tel, :cap, :obs)";

            OracleCommand cmd = DataClass.Command(sql);
            OracleParameter[] par = new OracleParameter[17];

            DataClass.Parameter(0, "id", "N", BENEFICIARIO_ID, cmd, par);
            DataClass.Parameter(1, "curp", "S", CURP, cmd, par);
            DataClass.Parameter(2, "upp", "S", UPP, cmd, par);
            DataClass.Parameter(3, "mun", "N", MUNICIPIO, cmd, par);
            DataClass.Parameter(4, "loc", "S", LOCALIDAD, cmd, par);
            DataClass.Parameter(5, "pat", "S", PATERNO, cmd, par);
            DataClass.Parameter(6, "mat", "S", MATERNO, cmd, par);
            DataClass.Parameter(7, "nom", "S", NOMBRE, cmd, par);
            DataClass.Parameter(8, "gen", "S", GENERO, cmd, par);
            DataClass.Parameter(9, "fe_nac", "D", FECHA_NAC, cmd, par);
            DataClass.Parameter(10, "ed_nac", "S", EDO_NAC, cmd, par);
            DataClass.Parameter(11, "dom", "S", DOMICILIO, cmd, par);
            DataClass.Parameter(12, "ed_civ", "S", EDO_CIVIL, cmd, par);
            DataClass.Parameter(13, "ocu", "S", OCUPACION, cmd, par);
            DataClass.Parameter(14, "tel", "S", TELEFONO, cmd, par);
            DataClass.Parameter(15, "cap", "N", CAPTURO, cmd, par);
            DataClass.Parameter(16, "obs", "S", OBSERVACION, cmd, par);

            return DataClass.Execute("Insertado con éxito",cmd);

        }
    }
}