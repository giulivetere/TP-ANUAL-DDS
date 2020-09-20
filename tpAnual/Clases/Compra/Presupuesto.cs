
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace TPANUAL {
    [Table("presupuesto")]
	public class Presupuesto {

        [Key]
        [Column("ID_Presupuesto")]
        public int ID_Presupuesto { get; set; }

        [Column("Detalle")]
        public string Detalle { get; set; }
        public Compra Compra { get; set; }

        [Column("ValorTotal")]
        public float ValorTotal { get; set; }
        public List<Item> Items { get; set ; }

        [NotMapped]
        public Proveedor Proveedor { get; set; }
        public List<DocumentoComercial> DocumentosComerciales { get; set; }

        public Presupuesto(Proveedor proveedor, List<Item> items, Compra compra, string detalle)
        {
            Proveedor = proveedor;
            Items = items;
            Detalle = detalle;
            DocumentosComerciales = null;
            Compra = compra;
        }

        public Presupuesto() { }



        public float valorTotal(){

			float valor = 0;

			foreach(Item item in Items)
            {
				valor += item.ValorTotal;
            }

            ValorTotal = valor;
			return valor;
		}

        public void agregarDocumentosComerciales(DocumentoComercial documento)
        {
            DocumentosComerciales.Add(documento);
        }

	}//end Presupuesto

}//end namespace TPANUAL