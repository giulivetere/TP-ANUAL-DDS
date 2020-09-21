///////////////////////////////////////////////////////////
//  Mundo.cs
//  Implementation of the Class Mundo
//  Generated by Enterprise Architect
//  Created on:      04-Sep-2020 11:29:31 PM
//  Original author: Ignacio Andre Keiniger
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Linq;
using System.Data.Entity;

namespace TPANUAL {
	public class API_MercadoLibre { // Convertir en singleton

		public List<Pais> paises;

		public API_MercadoLibre(){
            // Si ya hay algo, me aseguro que se vac�e
            paises = new List<Pais> { };

            // Lista actual de IDs de paises en la API
            List<string> id_paises = new List<string> { };

            // Pido a la api la lista de paises
            WebRequest request_id = HttpWebRequest.Create("https://api.mercadolibre.com/classified_locations/countries/");
            WebResponse response_id = request_id.GetResponse();
            StreamReader reader_id = new StreamReader(response_id.GetResponseStream());

            // Guardo el JSON leido en un objeto
            string JSON_ids = reader_id.ReadToEnd();
            List<ML_CountrySmall> objetoCountrySmall = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ML_CountrySmall>>(JSON_ids);

            List<String> noPaises = new List<string> { "Cross Border Trade", "newCOL" };

            // Agrego los IDs a la lista id_paises
            foreach (ML_CountrySmall pais in objetoCountrySmall)
            {
                if (!noPaises.Contains(pais.name))
                    id_paises.Add(pais.id);
            }

            paises = new List<Pais> { };
            // Recorro la lista de IDs de paises y agrego cada uno a la lista "Paises" de Mundo
            foreach (string id in id_paises)
            {
                paises.Add(new Pais(id));
            }
        }

        public void persistir(DB_Context contexto)
        {
            contexto.Database
                .ExecuteSqlCommand(
                "delete from ciudad; delete from provincia; delete from pais; delete from moneda;");

            /*
            List<Pais> listaPaises = new List<Pais> { };
            listaPaises.Add(new Pais("PA"));
            listaPaises.Add(new Pais("PR"));
            listaPaises.Add(new Pais("EC"));
            listaPaises.Add(new Pais("GT"));
            */

            Dictionary<string, string> paisMoneda = new Dictionary<string, string> { };

            foreach (Pais p in paises)
            //foreach (Pais p in listaPaises)
            {
                paisMoneda.Add(p.ID_Pais, p.Moneda.ID_Moneda);
                foreach (Moneda m in contexto.moneda)
                {
                    if (m.ID_Moneda == p.Moneda.ID_Moneda)
                    {
                        contexto.moneda.Remove(m);
                    }
                }
                try
                {
                    contexto.pais.Add(p);
                    contexto.SaveChanges();
                    Console.WriteLine("Pais \"" + p.Nombre + "\" agregado a la base de datos.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("_____________________________________________________________________________________");
                    Console.WriteLine("No se puede agregar el pais \"" + p.Nombre + "\" a la tabla.");
                    Console.WriteLine();
                    Console.WriteLine(e);
                }
            }

            // Asigno los FK de las monedas a los paises
            foreach (KeyValuePair<string, string> pm in paisMoneda)
            {
                Console.WriteLine("El ID del pais " + pm.Key + " es: " + pm.Value);
                contexto.Database.ExecuteSqlCommand
                ("Update pais set ID_Moneda = {0} where (ID_Pais = {1}) and (ID_Moneda is null);",
                pm.Value,
                pm.Key);
            }

            Console.WriteLine("_____________________________________________________________________________________");
            Console.WriteLine("\nCambios guardados.");
        }
	}
}