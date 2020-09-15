﻿///////////////////////////////////////////////////////////
//  Ciudad.cs
//  Implementation of the Class Ciudad
//  Generated by Enterprise Architect
//  Created on:      04-Sep-2020 11:29:28 PM
//  Original author: Ignacio Andre Keiniger
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Linq;
using API_MercadoLibre;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_MercadoLibre {
	[Table("ciudad")]
	public class Ciudad {

		[Key]
		[Column("ID_Ciudad")]
		public string ID_Ciudad { get; set; }
		[Column("Nombre")]
		public string Nombre { get; set; }
		[Column("ID_Provincia")]
		public string ID_Provincia { get; set; }

		public Ciudad(String _id, String _nombre)
        {
			ID_Ciudad = _id;
			Nombre = _nombre;

			this.imprimir();
		}

		public Ciudad() { }

		// Este constructor lo había hecho antes, ahora la clase Provincia usa el de arriba, pero 
		// lo dejo porque puede ser util si se necesita mas info de una ciudad
		public Ciudad(String _id){
			WebRequest request_ciudad = HttpWebRequest.Create("https://api.mercadolibre.com/classified_locations/cities/" + _id);
			bool leidoCorrectamente = true;
			try
			{
				request_ciudad.GetResponse();
			}
			catch (System.Net.WebException e)
			{
				Console.WriteLine("{0} Exception caught.", e);
				Console.WriteLine("Id de ciudad " + _id + " erroneo.");
				leidoCorrectamente = false;
			}
			if (leidoCorrectamente)
			{
				WebResponse response_ciudad = request_ciudad.GetResponse();
				StreamReader reader_ciudad = new StreamReader(response_ciudad.GetResponseStream());

				// Guardo el JSON leido en un objeto
				string objetoJSON_ciudad = reader_ciudad.ReadToEnd();
				ML_City ML_CityObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ML_City>(objetoJSON_ciudad);

				ID_Ciudad = ML_CityObject.id;
				Nombre = ML_CityObject.name;

				this.imprimir();
			}
		}

		public void imprimir()
        {
			Console.WriteLine();
			Console.WriteLine("			ID: " + ID_Ciudad);
			Console.WriteLine("			Nombre ciudad: " + Nombre);
		}
	}
}