using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public class Materia
    {
       public string Nombre { get; set; }

        public List<Recurso> recursos { get; set; }
        public Division division { get; set; }

    }
}