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
    public class CNegPacientes
    {

        CDatPacientes odatpacientes = new CDatPacientes();

        public bool guardar_paciente(CEntPacientes oenpaciente)
        {
            return odatpacientes.Guardar_Paciente(oenpaciente);
        }
        public bool anular_paciente(CEntPacientes oenpaciente)
        {
            return odatpacientes.Anular_Paciente(oenpaciente);
        }
        public DataSet consultar_paciente(CEntPacientes oenpaciente)
        {
            return odatpacientes.consultar_Paciente(oenpaciente);
        }
    }
}
