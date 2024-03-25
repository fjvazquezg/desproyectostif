using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace desarrollodeproyectos.Modelos
{
    public class ImagenBanner
    {
        public class imagenbanner
        {
            public int ID { get; set; }
            public int UsuarioID { get; set; }
            public int SuscripcionID { get; set; }
            public string RutaImagen { get; set; }
            // Otros campos según necesites
        }
    }
}