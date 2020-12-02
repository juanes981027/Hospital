using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapEntidad;

namespace CapaDatos
{
    public class CDatPacientes
    {
        CConexion oConexion = new CConexion();
        SqlCommand ocmd = new SqlCommand();

        public bool Anular_Paciente(CEntPacientes opaciente)
        {
            try
            {
                ocmd.Connection = oConexion.Conectar("BDHospital");
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "sp_anular_paciente";
                return true;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);

            }


        }

        public DataSet consultar_Paciente(CEntPacientes opaciente)
        {
            try
            {
                ocmd.Connection = oConexion.Conectar("BDHospital");
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "sp_consultar_paciente";
                ocmd.Parameters.Add("@pId_paciente", opaciente.Id_paciente1);
                SqlDataAdapter da = new SqlDataAdapter(ocmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);

            }
        }

        public bool Guardar_Paciente(CEntPacientes opaciente)
        {
            try
            {
                ocmd.Connection = oConexion.Conectar("BDHospital");
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "sp_guardar_paciente";
                ocmd.Parameters.Add("@pId_paciente", opaciente.Id_paciente1);
                ocmd.Parameters.Add("@ptip_doc", opaciente.Tip_doc);
                ocmd.Parameters.Add("@pnom_paciente", opaciente.Nom_paciente);
                ocmd.Parameters.Add("@pdir_paciente", opaciente.Dir_paciente);
                ocmd.Parameters.Add("@ptel_paciente", opaciente.Tel_paciente);
                ocmd.Parameters.Add("@pcel_paciente", opaciente.Cel_paciente);
                ocmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);

            }


        }
    }
}
