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
    public class CDatMedicos
    {

        CConexion oConexion = new CConexion();
        SqlCommand ocmd = new SqlCommand();

        public bool Anular_Medico(CEntMedicos omedicos)
        {
            try
            {
                ocmd.Connection = oConexion.Conectar("BDHospital");
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "sp_anular_medico";
                return true;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);

            }


        }

        public DataSet consultar_Medico(CEntMedicos omedicos)
        {
            try
            {
                ocmd.Connection = oConexion.Conectar("BDHospital");
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "sp_consultar_medico";
                ocmd.Parameters.Add("@pid_medico", omedicos.Id_medico);
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

        public bool Guardar_Medico(CEntMedicos omedicos)
        {
            try
            {
                ocmd.Connection = oConexion.Conectar("BDHospital");
                ocmd.CommandType = CommandType.StoredProcedure;
                ocmd.CommandText = "sp_guardar_medico";
                ocmd.Parameters.Add("@pid_medico", omedicos.Id_medico);
                ocmd.Parameters.Add("@pnom_medico", omedicos.Nom_medico);
                ocmd.Parameters.Add("@pespecialidad", omedicos.Especialidad);
                ocmd.Parameters.Add("@ptel_medico",omedicos.Tel_medico);
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
