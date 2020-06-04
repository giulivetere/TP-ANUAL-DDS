
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;



using TPANUAL;
namespace TPANUAL {
	public class Compra : TipoEgreso {

		private int cantidadDePresupuestosRequeridos;
		private BandejaDeMensajes bandeja;
		private Criterio criterio;
		private Presupuesto presupuestoElegido;
		private List<Presupuesto> presupuestos;
		private List<Producto> productosRequeridos;
		private List<Usuario> revisores;
		private Proveedor proveedor;
		private bool esConPresupuesto;

        public Compra(Criterio criterio, List<Usuario> revisores, List<Producto> productosRequeridos, bool esConPresupuesto, int cantidadDePresupuestosRequeridos)
        {
            Criterio = criterio;
            Presupuestos = new List<Presupuesto>();
            PresupuestoElegido = null;
            Revisores = revisores;
            ProductosRequeridos = productosRequeridos;
            Proveedor = null;
            EsConPresupuesto = esConPresupuesto;
            CantidadDePresupuestosRequeridos = cantidadDePresupuestosRequeridos;
            Bandeja = new BandejaDeMensajes();
        }

        public Criterio Criterio                  { get => criterio;            set => criterio = value; }
        public List<Presupuesto> Presupuestos     { get => presupuestos;        set => presupuestos = value; }
        public Presupuesto PresupuestoElegido     { get => presupuestoElegido;  set => presupuestoElegido = value; }
        public List<Usuario> Revisores			  { get => revisores;           set => revisores = value; }
        public List<Producto> ProductosRequeridos { get => productosRequeridos; set => productosRequeridos = value; }
        public Proveedor Proveedor                { get => proveedor;           set => proveedor = value; }
        public bool EsConPresupuesto              { get => esConPresupuesto;    set => esConPresupuesto = value; }
        public int CantidadDePresupuestosRequeridos { get => cantidadDePresupuestosRequeridos; set => cantidadDePresupuestosRequeridos = value; }
        public BandejaDeMensajes Bandeja { get => bandeja; set => bandeja = value; }

        public void agregarRevisor(Usuario usuario){
			Revisores.Add(usuario);
		}

        public void agregarPresupuesto(Presupuesto presupuesto)
        {
            if(EsConPresupuesto)
                presupuestos.Add(presupuesto);
        }

		public bool validarCompra(){

            return ValidadorDeCompra.getInstanceValidadorCompra.validarCompra(this);
		}

		public override float valorTotal(){

			float temporal = 0;

			if (esConPresupuesto)
			{
				temporal = presupuestoElegido.valorTotal();
			}
			else
			{
				foreach(Producto producto in ProductosRequeridos)
                {
					temporal += proveedor.damePrecio(producto.IdProducto);
                }
			}

			return temporal;
		}

		public bool presupuestoRequeridoEstaEnPresupuestos()
		{ 
			foreach(Presupuesto presupuesto in Presupuestos)
            {
				if(Equals(presupuestoElegido, presupuesto)){
					return true;
                }
            }

			return false;
        }

        public void mostrarMensajes(Usuario usuario)
        {
            if (usuario.esRevisor(this))
            {
                bandeja.imprimirMensajes();
            }
        }

    }//end Compra

}//end namespace TPANUAL