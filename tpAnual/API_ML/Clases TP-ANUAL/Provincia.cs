﻿///////////////////////////////////////////////////////////
//  Provincia.cs
//  Implementation of the Class Provincia
//  Generated by Enterprise Architect
//  Created on:      04-Sep-2020 11:29:34 PM
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
	[Table("provincia")]
	public class Provincia {
		
		[Key]
		[Column("ID_Provincia")]
		public string ID_Provincia { get; set; }

		[Column("Nombre")]
		public string Nombre { get; set; }

		[Column("ID_Pais")]
		public string ID_Pais { get; set; }

		public List<Ciudad> ciudades { get; set; }
		
		

		public Provincia(string _id){
			WebRequest request_provincia = HttpWebRequest.Create("https://api.mercadolibre.com/classified_locations/states/" + _id);
			bool leidoCorrectamente = true;
			try
			{
				request_provincia.GetResponse();
			}
			catch (System.Net.WebException e)
			{
				Console.WriteLine("{0} Exception caught.", e);
				Console.WriteLine("Id de provincia " + _id + " erroneo.");
				leidoCorrectamente = false;
			}
			if (leidoCorrectamente)
			{
				WebResponse response_provincia = request_provincia.GetResponse();
				StreamReader reader_provincia = new StreamReader(response_provincia.GetResponseStream());

				// Guardo el JSON leido en un objeto
				string objetoJSON_provincia = reader_provincia.ReadToEnd();
				ML_State ML_StateObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ML_State>(objetoJSON_provincia);

				ID_Provincia = ML_StateObject.id;
				Nombre = ML_StateObject.name;

                this.imprimir();

				llenarCiudades(ML_StateObject.cities);
			}
		}

		public Provincia() { }

		private void llenarCiudades(List<ML_PlaceSmall> _ciudades) 
		{
			ciudades = new List<Ciudad> { };
			// Chequeo que la lista no este vacia
			if (_ciudades?.Any() == true)
			{
				foreach (ML_PlaceSmall ciudad in _ciudades)
				{
					//Console.WriteLine(ciudad.name);
					ciudades.Add(new Ciudad(ciudad.id, ciudad.name));
				}
			}
		}

		public void imprimir()
        {
			Console.WriteLine("________________________________________________________");
			Console.WriteLine("		ID: " + ID_Provincia);
			Console.WriteLine("		Nombre provincia: " + Nombre);
		}
	}
}