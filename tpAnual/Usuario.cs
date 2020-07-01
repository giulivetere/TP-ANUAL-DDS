
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace TPANUAL {
	public class Usuario {

		private string constraseņa;
		private string nombreUsuario;
		private string tipoUsuario;

        public string Constraseņa { get => constraseņa; set => constraseņa = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }

        public Usuario(string constraseņa, string nombreUsuario)
        {
            this.Constraseņa = constraseņa;
            this.NombreUsuario = nombreUsuario;
            this.TipoUsuario = "estandar";
        }

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
            return ValidadorDeContraseņa.getInstanceValidadorContra.validarContraseņa(this.Constraseņa);
        }

	}//end Usuario

}//end namespace TPANUAL