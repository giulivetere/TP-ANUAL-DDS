﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TPANUAL
{
    [Table("operaciondeingreso")]
    public class OperacionDeIngreso
    {
        [Key]

        [Column("ID_Ingreso")]
        public int ID_Ingreso { get; set; }

        [Column("ID_Organizacion")]
        public int ID_Organizacion { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        [Column("Monto")]
        public float Monto { get; set; }

        public List<OperacionDeEgreso> EgresosAsociados { get; set; }
        public OperacionDeIngreso(string descripcion, List<OperacionDeEgreso> egresosAsociados, float monto)
        {
            this.Descripcion = descripcion;
            this.EgresosAsociados = egresosAsociados;
            this.Monto = monto;
        }
        public OperacionDeIngreso() { }

        public void agregarOperacionDeEgreso(OperacionDeEgreso operacion)
        {
            EgresosAsociados.Add(operacion);
        }
    }
}