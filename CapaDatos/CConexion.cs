using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    class CConexion
    {
        public SqlConnection Conectar(string Cnx)
        {
            try
            {

                SqlConnection oConectar = new SqlConnection(ConfigurationSettings.AppSettings[Cnx].ToString());
                oConectar.Open(); //Abrir la conexion de la base de datos
                return oConectar;
            }
            catch(Exception err)
            {
                throw new Exception(err.Message);//este me da el codigo de error si existe
            }
        }

    }
}
