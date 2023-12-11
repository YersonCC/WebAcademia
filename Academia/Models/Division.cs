using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public class Division
    {
        public string Nombre { get; set; }

        public List<Materia> materias { get; set; }
        public SubArea subArea { get; set; }
    }
}