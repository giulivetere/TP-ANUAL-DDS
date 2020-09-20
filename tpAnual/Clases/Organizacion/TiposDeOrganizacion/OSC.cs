
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TPANUAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPANUAL {

    [Table("organizacion")]
    public class OSC : Organizacion{
        public OSC(Actividad actividad, int cantidadPersonal, string nombreFicticio, float promedioVentasAnuales, TipoEntidad tipoEntidad, List<Usuario> usuarios)
        {
            Actividad = actividad;
            CantidadPersonal = cantidadPersonal;
            EsActividadComisionistaoAgenciaDeViaje = false;
            NombreFicticio = nombreFicticio;
            OperacionesDeEgreso = new List<OperacionDeEgreso>();
            PromedioVentasAnuales = promedioVentasAnuales;
            TipoEntidad = tipoEntidad;
            Usuarios = usuarios;
        }

    }//end OSC

}//end namespace TPANUAL