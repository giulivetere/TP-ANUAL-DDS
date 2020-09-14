
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using TPANUAL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL {

    [Table("entidadbase")]
	public class EntidadBase : TipoEntidad {

        [Key]

        [Column("ID_EntidadBase")]
        public int ID_EntidadBase { get; set; }

        [Column("ID_Organizacion")]
        public int ID_Organizacion { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        [Column("ID_EntidadJuridica")]
        public int ID_EntidadJuridica { get; set; }
        public EntidadJuridica JuridicaAsociada { get; set; }

        public EntidadBase(string descripcion, EntidadJuridica juridicaAsociada)
        {
            this.Descripcion = descripcion;
            this.JuridicaAsociada = juridicaAsociada;
        }
        public EntidadBase() { }

    }//end Entidad base

}//end namespace TPANUAL