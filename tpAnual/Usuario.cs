
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace TPANUAL {
	public class Usuario {

		private string constraseņa;
		private string nombreUsuario;
		private string tipoUsuario;

        public Usuario(string constraseņa, string nombreUsuario)
        {
            this.constraseņa = constraseņa;
            this.nombreUsuario = nombreUsuario;
            this.tipoUsuario = "estandar";
        }

        public void verMensajes(Compra compra)
        {
            compra.mostrarMensajes(this);
        }

        public bool esRevisor(Compra compra)
        {
            foreach (Usuario usuario in compra.Revisores)
            {
                if (Equals(this, usuario))
                {
                    return true;
                }
            }

            return false;
        }

        public void cambiarTipoUsuario()
        {
            if(tipoUsuario == "estandar")
            {
                tipoUsuario = "administrador";
            }
            else{
                tipoUsuario = "estandar";
            }
        }

	}//end Usuario

}//end namespace TPANUAL