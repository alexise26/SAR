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
    // [System.Web.Script.Services.ScriptService]
    public class postService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public String postBeneficiario( string curp="", string upp="", string municipio = "", string localidad = "", string paterno = "", string materno = "", string nombre = "", string genero = "", string fecha_nac = "", string edo_nac = "", string domicilio = "", string edo_civil = "", string ocupacion = "", string telefono = "", string capturo = "", string observacion = "")
        {
            Beneficiario beneficiario = new Beneficiario( curp, upp, municipio, localidad, paterno, materno, nombre, genero, fecha_nac, edo_nac, domicilio, edo_civil, ocupacion, telefono, capturo, observacion);
    
            return beneficiario.Save();
        }
    }
}
