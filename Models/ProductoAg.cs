using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using SAR.Data;

namespace SAR.Models
{
    public class ProductoAg
    {
        protected String PRODUCTO_ID;
        protected String PRODUCTO_DES;
        protected String OFICIO_APROBACION;
        protected String APORTACION_PRODUCTORES;
        protected String APORTACION_GOBIERNO;
        protected String FECHA_RECIBIDO_PLANEA;
        protected String CICLO;

        //Create Producto
        public ProductoAg(string producto_des, string oficio_aprobacion, string aportacion_productores, string aportacion_gobierno, string fecha_recibido_planea, string ciclo) {
            this.PRODUCTO_ID = (DataClass.MaxMin("PRODUCTOS", "PRODUCTO_ID", "MAX") + 1).ToString();
            this.PRODUCTO_DES = producto_des;
            this.OFICIO_APROBACION = oficio_aprobacion;
            this.APORTACION_PRODUCTORES = aportacion_productores;
            this.APORTACION_GOBIERNO = aportacion_gobierno;
            this.FECHA_RECIBIDO_PLANEA = fecha_recibido_planea;
            this.CICLO = ciclo;
        }
        //Save Producto in Database
        public String Save()
        {
            String sql = "Insert into PRODUCTOS (PRODUCTO_ID,PRODUCTO_DES,OFICIO_APROBACION,APORTACION_PRODUCTORES,APORTACION_GOBIERNO,FECHA_RECIBIDO_PLANEA,CICLO)" + "VALUES(:producto_id,:producto_des,:oficio_aprobacion,:aportacion_productores,:aportacion_gobierno,:fecha_recibido_planea,:ciclo)";

            OracleCommand cmd = DataClass.Command(sql);
            OracleParameter[] par = new OracleParameter[7];

            DataClass.Parameter(0, "producto_id", "N", this.PRODUCTO_ID, cmd, par);
            DataClass.Parameter(1, "producto_des", "S", this.PRODUCTO_DES, cmd, par);
            DataClass.Parameter(2, "oficio_aprobacion", "S", this.OFICIO_APROBACION, cmd, par);
            DataClass.Parameter(3, "aportacion_productores", "F", this.APORTACION_PRODUCTORES, cmd, par);
            DataClass.Parameter(4, "aportacion_gobierno", "F", this.APORTACION_GOBIERNO, cmd, par);
            DataClass.Parameter(5, "fecha_recibido_planea", "D", this.FECHA_RECIBIDO_PLANEA, cmd, par);
            DataClass.Parameter(6, "ciclo", "N", this.CICLO, cmd, par);


            return DataClass.Execute("Insertado con éxito", cmd);

        }
    }
}