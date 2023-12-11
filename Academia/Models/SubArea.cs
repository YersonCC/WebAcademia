using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public class SubArea
    {
        public string Nombre { get; set; }
        
        public Area Area { get; set; }
        public List<Division> divisions { get; set; }
    }
}