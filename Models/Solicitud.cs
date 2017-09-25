using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAR.Models
{
    public class Solicitud
    {
        protected String BENEFICIARIO;
        protected String FOLIO;
        protected String CICLO;
        protected String CAPTURO;
        protected String FECHA_CAPTURA;
        protected String OBSERVACIONES;

        //Create a new Solicitud
        public Solicitud(string beneficiario, string folio, string ciclo, string capturo, string fecha_captura, string observaciones) {
            this.BENEFICIARIO = beneficiario;
            this.FOLIO = folio;
            this.CICLO = ciclo;
            this.CAPTURO = capturo;
            this.FECHA_CAPTURA = fecha_captura;
            this.OBSERVACIONES = observaciones;
        }

    }
}