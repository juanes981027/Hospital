using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapEntidad;
using CapNegocio;

namespace Hospital
{
    public partial class Pacientes : System.Web.UI.Page
    {

        CNegCitas oNegCitas = new CNegCitas();
        CEntCitas oEntCitas = new CEntCitas();
        CNegPacientes oNegPacientes = new CNegPacientes();
        CEntPacientes oEntPacientes = new CEntPacientes();
        CNegMedicos oNegMedicos = new CNegMedicos();
        CEntMedicos oEntMedicos = new CEntMedicos();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Limpiar()
        {

            txtidPaciente.Text = "";
            txtTipoDocumento.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCelular.Text = "";
            label5.Text = "";

        }

      

       

        protected void btConsultar_Click1(object sender, EventArgs e)
        {
            if (txtidPaciente.Text == "")
            {
                label5.Text = "No se ha ingresado ningun numero de documento";
                txtidPaciente.Focus();
            }
            else
            {
                DataSet ds = new DataSet();
                oEntPacientes.Id_paciente1 = txtidPaciente.Text;
                ds = oNegPacientes.consultar_paciente(oEntPacientes);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    label5.Text = "El codigo esta disponible para crear nuevo paciente";
                    txtidPaciente.Focus();

                }
                else
                {
                    
                    txtTipoDocumento.Text = ds.Tables[0].Rows[0]["tip_doc"].ToString();
                    txtNombre.Text = ds.Tables[0].Rows[0]["nom_paciente"].ToString();
                    txtDireccion.Text = ds.Tables[0].Rows[0]["dir_paciente"].ToString();
                    txtTelefono.Text = ds.Tables[0].Rows[0]["tel_paciente"].ToString();
                    txtCelular.Text = ds.Tables[0].Rows[0]["cel_paciente"].ToString();


                }
            }

        }

        protected void btLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btguardar_Click(object sender, EventArgs e)
        {
            oEntPacientes.Id_paciente1 = txtidPaciente.Text;
            oEntPacientes.Tip_doc = txtTipoDocumento.Text;
            oEntPacientes.Nom_paciente = txtNombre.Text;
            oEntPacientes.Dir_paciente = txtDireccion.Text;
            oEntPacientes.Tel_paciente = txtTelefono.Text;
            oEntPacientes.Cel_paciente = txtCelular.Text;

            if (oNegPacientes.guardar_paciente(oEntPacientes))
            {
                label5.Text = "Registro guardado........";
            }
            else
            {
                label5.Text = "Error... Registro NO GUARDADO.......";
            }
        }
    }
}