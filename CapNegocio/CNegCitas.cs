using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapEntidad;
using System.Data;

namespace CapNegocio
{
    public class CNegCitas
    {
        CDatCitas odatcitas = new CDatCitas();

        public bool guardar_cita(CEntCitas oencitas)
        {
            return odatcitas.Guardar_Cita(oencitas);
        }
        public bool anular_citas(CEntCitas oencita)
        {
            return odatcitas.anular_Cita(oencita);
        }
        public DataSet consultar_cita(CEntCitas oencita)
        {
            return odatcitas.consultar_Cita(oencita);
        }


        
    }
}
