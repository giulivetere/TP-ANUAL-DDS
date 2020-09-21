///////////////////////////////////////////////////////////
//  Orden-Valor-PrimeroEgreso.cs
//  Implementation of the Class Orden-Valor-PrimeroEgreso
//  Generated by Enterprise Architect
//  Created on:      12-Sep-2020 7:23:03 PM
//  Original author: Franco
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using TPANUAL;

public class Orden_Valor_PrimeroEgreso : CriterioVinculador {

	public Orden_Valor_PrimeroEgreso(){

	}

	public override void vincular(DB_Context _contexto, Organizacion _org){
		/*
		Organizacion o;

		if (_org is Empresa)
		{
			o = _contexto.empresas
				.Find(_org.ID_Organizacion);
		}
        else
        {
			o = _contexto.oscs
				.Find(_org.ID_Organizacion);
		}
		*/

        List<OperacionDeEgreso> listaEgresos = new List<OperacionDeEgreso>();
		listaEgresos = _contexto.operacionDeEgreso
			.SqlQuery("select * from operaciondeegreso where ID_Organizacion = {0}"
				,_org.ID_Organizacion)
			.ToList();

        List<OperacionDeIngreso> listaIngresos = new List<OperacionDeIngreso>();
		listaIngresos= _contexto.operacionDeIngreso
			.SqlQuery("select * from operaciondeingreso where ID_Organizacion = {0}"
				,_org.ID_Organizacion)
			.ToList();

		Console.WriteLine(_org.ID_Organizacion);
		Console.WriteLine(_org.NombreFicticio);
		Console.WriteLine(listaEgresos.Count());
		Console.WriteLine(listaIngresos.Count());


		/*
		List<OperacionDeEgreso> listaEgresos = _contexto.operacionDeEgreso
			.SqlQuery("SELECT * FROM OperacionDeEgreso ORDER BY ValorTotal ASC")
			.ToList<OperacionDeEgreso>();

		List<OperacionDeIngreso> listaIngresos = _contexto.operacionDeIngreso
			.SqlQuery("SELECT * FROM OperacionDeIngreso ORDER BY Monto ASC")
			.ToList<OperacionDeIngreso>();
		*/

		Console.WriteLine("Lista egresos [0]", listaEgresos.Count());

		Console.WriteLine("Lista ingresos [0]", listaIngresos.Count());

		/*
		// Guarda la diferencia restante entre ingreso y egreso
		float montoIngresoRestante;
		foreach (OperacionDeIngreso ingreso in listaIngresos)
		{
			// Le asigna el valor del ingreso al principio del foreach
			montoIngresoRestante = ingreso.Monto;

			// Para cada egreso 
			foreach (OperacionDeEgreso egreso in listaEgresos)
			{
				// Chequeo si puedo asociar el egreso al ingreso
				if ((ingreso.Monto >= egreso.valorTotal()) ||
				   // O si lo que me falta para asociarlo es mayor al valor del egreso 
				   (montoIngresoRestante >= egreso.valorTotal()))
				{
					// Si se puede, lo asocio
					base.asociarEgresoIngreso(egreso, ingreso);

					// Guardo lo que me falta para llenar el ingreso
					montoIngresoRestante -= egreso.valorTotal();

					// Saco el egreso que acabo de vicular, para no vincularlo de nuevo a nada
					listaEgresos.Remove(egreso);
				}
			}
		}*/

	}
}