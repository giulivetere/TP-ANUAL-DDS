﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SqlClient;

namespace TPANUAL.Clases.DAO
{
    public class EntidadJuridicaProveedoraDAO
    {
        private EntidadJuridicaProveedoraDAO() { }

        public static EntidadJuridicaProveedora obtenerEntidadJuridicaProveedora(int _id)
        {
            using var contexto = new DB_Context();
            var prov = (EntidadJuridicaProveedora)contexto.entidadJuridicaProveedora.Find(_id);
            return prov;
        }
    }
}
