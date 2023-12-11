using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public class Recurso
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string NombreAu { get; set; }
        public string Descripcion { get; set; }
        public string Nivel { get; set; }
        public string Fecha_Publicacion { get; set; }

        public Autor autor { get; set; }
        public Materia materia { get; set; }
        public string Preview { get; set; }
    }
}