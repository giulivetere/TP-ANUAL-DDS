
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL {

    [Table("usuario")]
	public class Usuario {

        [Key]

        [Column("ID_Usuario")]
        public int ID_Usuario { get; set; }

        [Column("Contraseņa")]
        public string Contraseņa { get; set; }

        [Column("NombreUsuario")]
        public string NombreUsuario { get; set; }

        [Column("TipoUsuario")]
        public string TipoUsuario { get; set; }

        public Usuario(string contraseņa, string nombreUsuario)
        {
            this.Contraseņa = contraseņa;
            this.NombreUsuario = nombreUsuario;
            this.TipoUsuario = "estandar";
        }

        public Usuario() { }

        public void verMensajes(Compra compra)
        {
            compra.mostrarMensajes(this);
        }


        public void cambiarTipoUsuario()
        {
            if(TipoUsuario == "estandar")
            {
                TipoUsuario = "administrador";
            }
            else{
                TipoUsuario = "estandar";
            }
        }

        public bool validarContraseņa()
        {
            return ValidadorDeContraseņa.getInstanceValidadorContra.validarContraseņa(this.Contraseņa);
        }

	}//end Usuario

}//end namespace TPANUAL