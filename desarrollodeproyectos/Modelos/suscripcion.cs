using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace desarrollodeproyectos.Modelos
{
    public class suscripcion
    {
        public class Suscripcion
        {
            public int ID { get; set; }
            public int UsuarioID { get; set; }
            public int TipoSuscripcion { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            // Otros campos según necesites
        }
    }
}