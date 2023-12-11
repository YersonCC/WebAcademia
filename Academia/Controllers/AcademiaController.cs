using Academia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VDS.RDF.Query;

namespace Academia.Controllers
{
    public class AcademiaController : Controller
    {
        private static SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://localhost:3030/OntoAcademia/sparql"));
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CatalogoRecursos(string searchTerm)
        {
            List<Recurso> ListaRe = new List<Recurso>();

            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                "PREFIX dato: <http://www.semanticweb.org/yerso/ontologies/2023/10/Academia#> " +
                "PREFIX xsd:  <http://www.w3.org/2001/XMLSchema#> " +
                "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +

                "SELECT ?Id ?Nombre ?Descripcion ?Nivel " +
                "WHERE{ " +
                    "?Recurso rdf:type dato:Recurso. " +
                    "?Recurso dato:Id ?Id. " +
                    "?Recurso dato:Nombre ?Nombre. " +
                    "?Recurso dato:Nivel ?Nivel " +
                    "} "
                );

            foreach (var result in resultado.Results)
            {
                Recurso recurso = new Recurso();

                var dato = result.ToList();

                recurso.Id = dato[0].Value.ToString();
                recurso.Nombre = dato[1].Value.ToString();
                recurso.Nivel = dato[2].Value.ToString();

                ListaRe.Add(recurso);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ListaRe = ListaRe.Where(a => a.Nombre.Contains(searchTerm)).ToList();
            }

            return View(ListaRe);
        }


        public ActionResult Area(string searchTerm)
        {
            List<Area> ListaAr = new List<Area>();

            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                "PREFIX dato: <http://www.semanticweb.org/yerso/ontologies/2023/10/Academia#> " +
                "PREFIX xsd:  <http://www.w3.org/2001/XMLSchema#> " +
                "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +

                "SELECT ?Nombre " +
                "WHERE { " +
                "?Area rdf:type dato:Area. " +
                "?Area dato:Nombre ?Nombre. " +
                
                "} "
            );

            foreach (var result in resultado.Results)
            {
                Area area = new Area();

                var datos = result.ToList();

                area.Nombre = datos[0].Value.ToString();


                ListaAr.Add(area);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ListaAr = ListaAr.Where(a => a.Nombre.Contains(searchTerm) || a.SubArea.Any(sa => sa.Nombre.Contains(searchTerm))).ToList();
            }

            return View(ListaAr);
        }


        public ActionResult SubArea(string searchTerm)
        {
            List<SubArea> ListaSubA = new List<SubArea>();

            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                "PREFIX dato: <http://www.semanticweb.org/yerso/ontologies/2023/10/Academia#> " +
                "PREFIX xsd:  <http://www.w3.org/2001/XMLSchema#> " +
                "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +

                "SELECT ?Nombre " +
                "WHERE{ " +
                    "?SubAr rdf:type dato:SubArea. " +
                    "?SubAr dato:Nombre ?Nombre. " +
                    "} "
                );

            foreach (var result in resultado.Results)
            {
                SubArea subarea = new SubArea();

                var dato = result.ToList();

                subarea.Nombre = dato[0].Value.ToString();

                ListaSubA.Add(subarea);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ListaSubA = ListaSubA.Where(a => a.Nombre.Contains(searchTerm)).ToList();
            }


            return View(ListaSubA);
        }

        public ActionResult Division(string searchTerm)
        {
            List<Division> ListaDiv = new List<Division>();

            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                "PREFIX dato: <http://www.semanticweb.org/yerso/ontologies/2023/10/Academia#> " +
                "PREFIX xsd:  <http://www.w3.org/2001/XMLSchema#> " +
                "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +

                "SELECT ?Nombre " +
                "WHERE{ " +
                    "?Division rdf:type dato:Division. " +
                    "?Division dato:Nombre ?Nombre. " +
                    "} "
                );

            foreach (var result in resultado.Results)
            {
                Division division = new Division();

                var dato = result.ToList();

                division.Nombre = dato[0].Value.ToString();

                ListaDiv.Add(division);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ListaDiv = ListaDiv.Where(a => a.Nombre.Contains(searchTerm)).ToList();
            }

            return View(ListaDiv);
        }

        public ActionResult Materia(string searchTerm)
        {
            List<Materia> ListaMa = new List<Materia>();

            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                "PREFIX dato: <http://www.semanticweb.org/yerso/ontologies/2023/10/Academia#> " +
                "PREFIX xsd:  <http://www.w3.org/2001/XMLSchema#> " +
                "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +

                "SELECT ?Nombre " +
                "WHERE{ " +
                    "?Materia rdf:type dato:Materia. " +
                    "?Materia dato:Nombre ?Nombre. " +
                    "} "
                );

            foreach (var result in resultado.Results)
            {
                Materia materia = new Materia();

                var dato = result.ToList();

                materia.Nombre = dato[0].Value.ToString();

                ListaMa.Add(materia);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ListaMa = ListaMa.Where(a => a.Nombre.Contains(searchTerm)).ToList();
            }

            return View(ListaMa);
        }

        public ActionResult Autor(string searchTerm)
        {
            List<Autor> ListaAu = new List<Autor>();

            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                "PREFIX dato: <http://www.semanticweb.org/yerso/ontologies/2023/10/Academia#> " +
                "PREFIX xsd:  <http://www.w3.org/2001/XMLSchema#> " +
                "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +

                "SELECT DISTINCT ?Nombre ?Experiencia " +
                "WHERE{ " +
                    "?au rdf:type dato:Autor. " +
                    "?au dato:Nombre ?Nombre. " +
                    "?au dato:Anios_Exp ?Experiencia. " +
                    "} "
                );

            foreach (var result in resultado.Results)
            {
                Autor autor = new Autor();

                var dato = result.ToList();

                autor.Nombre = dato[0].Value.ToString();
                autor.Anios_Exp = dato[1].Value.ToString();

                ListaAu.Add(autor);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ListaAu = ListaAu.Where(a => a.Nombre.Contains(searchTerm)).ToList();
            }

            return View(ListaAu);
        }

        public ActionResult DetallAutor(string Nombre)
        {
            Autor autor = new Autor();

            const string comilla = "\"";

            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                "PREFIX dato: <http://www.semanticweb.org/yerso/ontologies/2023/10/Academia#> " +
                "PREFIX xsd:  <http://www.w3.org/2001/XMLSchema#> " +
                "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +

                "SELECT DISTINCT ?Experiencia " +
                "WHERE{ " +
                    "?aut rdf:type dato:Autor. " +
                    "?aut  dato:Nombre " + comilla + Nombre + comilla + ". " +
                    "?aut dato:Anios_Exp ?Experiencia. " +
                    "} "
                );

            var datos = resultado.Results.Single().ToList();

            autor.Nombre = Nombre;
            autor.Anios_Exp = datos[0].Value.ToString().Substring(0, 2);

            List<Recurso> recursos = new List<Recurso>();

            SparqlResultSet listrec = endpoint.QueryWithResultSet(
                "PREFIX dato: <http://www.semanticweb.org/yerso/ontologies/2023/10/Academia#> " +
                "PREFIX xsd:  <http://www.w3.org/2001/XMLSchema#> " +
                "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +

                "SELECT ?NombreRec " +
                "WHERE{ " +
                    "?rec rdf:type dato:Recurso. " +
                    "?rec  dato:Nombre  ?NombreRec. " +
                    "?rec dato:Pertenece " + comilla + Nombre + comilla + ". " +
                    "} "
                );

            foreach (var recurso in listrec.Results)
            {
                Recurso rec = new Recurso();
                var info = recurso.ToList();
                rec.Nombre = info[0].Value.ToString();
                recursos.Add(rec);

            }

            autor.lrecursos = recursos;

            return View(autor);
        }

        public ActionResult DetalleRecurso(string Id)
        {
            Recurso recurso = new Recurso();
            const string comilla = "\"";

            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                "PREFIX dato: <http://www.semanticweb.org/yerso/ontologies/2023/10/Academia#> " +
                "PREFIX xsd:  <http://www.w3.org/2001/XMLSchema#> " +
                "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +

                "SELECT  ?Nombre ?Nom_aut ?Descripcion ?Nivel ?Fecha_Publicacion " +
                "WHERE{ " +
                    "?recursoid rdf:type dato:Recurso. " +
                    " ?aut rdf:type dato:Autor. " +
                    "?recursoid dato:Id " + comilla + Id + comilla + ". " +
                    "?recursoid dato:Nombre ?Nombre. " +
                    "?recursoid dato:Descripcion ?Descripcion. " +
                    "?recursoid dato:Nivel ?Nivel. " +
                    "?recursoid dato:Fecha_Publicacion ?Fecha_Publicacion. " +
                    "?recursoid dato:Pertenece ?aut. " +
                    " ?aut dato:Nombre ?Nom_aut. " +

                    " } "
                );

            var datos = resultado.Results.Single().ToList();

            recurso.Nombre = datos[0].Value.ToString();
            recurso.NombreAu = datos[1].Value.ToString();
            recurso.Descripcion = datos[2].Value.ToString();
            recurso.Nivel = datos[3].Value.ToString();
            recurso.Fecha_Publicacion = datos[4].Value.ToString().Substring(0, 10);
            return View(recurso);
        }

        public ActionResult ListSub_Area(string Nombre, string searchTerm)
        {
            List<SubArea> ListaSubA = new List<SubArea>();
            const string comilla = "\"";

            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                "PREFIX dato: <http://www.semanticweb.org/yerso/ontologies/2023/10/Academia#> " +
                "PREFIX xsd:  <http://www.w3.org/2001/XMLSchema#> " +
                "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +

                "SELECT ?NombreAre ?Nombresub " +
                "WHERE{ " +
                  "?area rdf:type dato:Area. " +
                  "?subarea rdf:type dato:SubArea. " +
                  "?area dato:Nombre " + comilla + Nombre + comilla + ". " +
                  "?area dato:Nombre ?NombreAre. " +
                  "?area dato:Tiene ?subarea. " +
                  "?subarea dato:Nombre ?Nombresub. " +
                    "} "
                );

            foreach (var result in resultado.Results)
            {
                SubArea subarea = new SubArea();

                var dato = result.ToList();

                subarea.Nombre = dato[1].Value.ToString();
                
                ListaSubA.Add(subarea);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ListaSubA = ListaSubA.Where(a => a.Nombre.Contains(searchTerm)).ToList();
            }

            return View(ListaSubA);
        }

        public ActionResult ListDiv_Sub(string Nombre, string searchTerm)
        {
            List<Division> ListaDiv = new List<Division>();
            const string comilla = "\"";

            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                "PREFIX dato: <http://www.semanticweb.org/yerso/ontologies/2023/10/Academia#> " +
                "PREFIX xsd:  <http://www.w3.org/2001/XMLSchema#> " +
                "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +

                "SELECT ?NombreSub ?NombreDiv " +
                "WHERE{ " +
                  "?subdi rdf:type dato:SubArea. " +
                  "?subdi dato:Nombre " + comilla + Nombre + comilla + ". " +
                  "?subdi dato:Nombre ?NombreSub. " +
                  "?subdi dato:Posee ?div. " +
                  "?div dato:Nombre ?NombreDiv. " +
                    "} "
                );

            foreach (var result in resultado.Results)
            {
                Division division = new Division();

                var dato = result.ToList();

                division.Nombre = dato[1].Value.ToString();

                ListaDiv.Add(division);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ListaDiv = ListaDiv.Where(a => a.Nombre.Contains(searchTerm)).ToList();
            }

            return View(ListaDiv);
        }

        public ActionResult ListMa_Div(string Nombre, string searchTerm)
        {
            List<Materia> ListaMa = new List<Materia>();
            const string comilla = "\"";

            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                "PREFIX dato: <http://www.semanticweb.org/yerso/ontologies/2023/10/Academia#> " +
                "PREFIX xsd:  <http://www.w3.org/2001/XMLSchema#> " +
                "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +

                "SELECT ?NombreDiv ?NombreMat " +
                "WHERE{ " +
                  "?div rdf:type dato:Division. " +
                  "?div dato:Nombre " + comilla + Nombre + comilla + ". " +
                  "?div dato:Nombre ?NombreDiv. " +
                  "?div dato:Contiene ?mat. " +
                  "?mat dato:Nombre ?NombreMat. " +
                    "} "
                );

            foreach (var result in resultado.Results)
            {
                Materia materia = new Materia();

                var dato = result.ToList();

                materia.Nombre = dato[1].Value.ToString();

                ListaMa.Add(materia);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ListaMa = ListaMa.Where(a => a.Nombre.Contains(searchTerm)).ToList();
            }

            return View(ListaMa);
        }

        public ActionResult ListRec_Ma(string Nombre, string searchTerm)
        {
            List<Recurso> ListaRec = new List<Recurso>();
            const string comilla = "\"";

            SparqlResultSet resultado = endpoint.QueryWithResultSet(
                "PREFIX dato: <http://www.semanticweb.org/yerso/ontologies/2023/10/Academia#> " +
                "PREFIX xsd:  <http://www.w3.org/2001/XMLSchema#> " +
                "PREFIX owl: <http://www.w3.org/2002/07/owl#> " +
                "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "PREFIX xml: <http://www.w3.org/XML/1998/namespace/> " +

                "SELECT  ?Id ?NombreRec " +
                "WHERE{ " +
                  "?mat rdf:type dato:Materia. " +
                  "?mat dato:Nombre " + comilla + Nombre + comilla + ". " +
                  "?mat dato:Incluye ?rec. " +
                  "?rec dato:Id ?Id. " +
                  "?rec dato:Nombre ?NombreRec. " +
                    "} "
                );

            foreach (var result in resultado.Results)
            {
                Recurso recursom = new Recurso();

                var dato = result.ToList();

                recursom.Nombre = dato[1].Value.ToString();
                recursom.Id = dato[0].Value.ToString();

                ListaRec.Add(recursom);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                ListaRec = ListaRec.Where(a => a.Nombre.Contains(searchTerm)).ToList();
            }

            return View(ListaRec);
        }

    }
}