using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public class Autor
    {
        public  string  Nombre { get; set; }
        public string Anios_Exp { get; set; }
        public string NombRec { get; set; }

        public List<Recurso> lrecursos { get; set; }
    }
}