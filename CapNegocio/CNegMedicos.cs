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
    public class CNegMedicos
    {

        CDatMedicos odatmedic = new CDatMedicos();

        public bool guardar_medico(CEntMedicos oenmedic)
        {
            return odatmedic.Guardar_Medico(oenmedic);
        }
        public bool anular_medico(CEntMedicos oenmedic)
        {
            return odatmedic.Anular_Medico(oenmedic);
        }
        public DataSet consultar_medico(CEntMedicos oenmedic)
        {
            return odatmedic.consultar_Medico(oenmedic);
        }

    }
}
