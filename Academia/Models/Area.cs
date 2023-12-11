using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academia.Models
{
    public class Area
    {
        public string Nombre { get; set; }

        public List<SubArea> SubArea { get; set; }

    }
}