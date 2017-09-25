using SAR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;


namespace SAR.Services
{
    /// <summary>
    /// Descripción breve de postService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class postService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        //Create and insert a new "Beneficiario" from app.js data
        public String postBeneficiario( string curp="", string upp="", string municipio = "", string localidad = "", string paterno = "", string materno = "", string nombre = "", string genero = "", string fecha_nac = "", string edo_nac = "", string domicilio = "", string edo_civil = "", string ocupacion = "", string telefono = "", string capturo = "", string observacion = "")
        {
            Beneficiario beneficiario = new Beneficiario( curp, upp, municipio, localidad, paterno, materno, nombre, genero, fecha_nac, edo_nac, domicilio, edo_civil, ocupacion, telefono, capturo, observacion);
    
            return beneficiario.Save();
        }

        [WebMethod]
        //Create and insert a new "Ciclo" from app.js data
        public String postCiclo( string ciclo_des="", string estatus="", string ciclo_cve="",string fecha_apertura="", string fecha_cierre="")
        {
            if (fecha_apertura.Equals("1900-12-31"))
            {
                fecha_apertura = null;
            }
            if (fecha_cierre.Equals("1900-12-31"))
            {
                fecha_cierre = null;
            }
            Ciclo ciclo = new Ciclo(ciclo_des, estatus, ciclo_cve, fecha_apertura, fecha_cierre);

            return ciclo.Save();
        }

        [WebMethod]
        //Create and insert a new "Producto" from app.js data
        public String postProducto(string producto_des, string oficio_aprobacion, string aportacion_productores, string aportacion_gobierno, string fecha_recibido_planea, string ciclo)
        {
            ProductoAg producto = new ProductoAg(producto_des, oficio_aprobacion, aportacion_productores, aportacion_gobierno, fecha_recibido_planea, ciclo);

            return producto.Save();
        }

        [WebMethod]
        //Create and insert a new "Solicitud Agrícola" from app.js data
        public String postSolicitudAg(string beneficiario, string folio, string producto, string tipo_solicitud, string propia_ejidal, string renta, string ciclo, string tipo_agricultura, string dano_0_40, string dano_41_70, string dano_mas_70, string capturo, string fecha_captura, string observaciones)
        {
            SolicitudAg solicitudag = new SolicitudAg( beneficiario, folio, producto, tipo_solicitud, propia_ejidal, renta, ciclo, tipo_agricultura, dano_0_40, dano_41_70, dano_mas_70, capturo, fecha_captura, observaciones);

            return solicitudag.Save();
        }


    }
}
