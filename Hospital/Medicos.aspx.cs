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
    public partial class Medicos : System.Web.UI.Page
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

            txtespecialidad.Text= "";
            txtidMedico.Text = "";
            txtnombre.Text = "";
            txttelefono.Text = "";
            Label5.Text = "";

        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            if (txtidMedico.Text == "")
            {
                Label5.Text = "No se ha ingresado ningun codigo de cita";
                txtidMedico.Focus();
            }
            else
            {
                DataSet ds = new DataSet();
                oEntMedicos.Id_medico = txtidMedico.Text;
                ds = oNegMedicos.consultar_medico(oEntMedicos);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    Label5.Text = "El codigo esta disponible para crear nuevo medico";
                    txtnombre.Focus();

                }
                else
                {
                    txtnombre.Text = ds.Tables[0].Rows[0]["nom_medico"].ToString();
                    txtespecialidad.Text = ds.Tables[0].Rows[0]["especialidad"].ToString();
                    txttelefono.Text = ds.Tables[0].Rows[0]["tel_medico"].ToString();
                   

                }
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            oEntMedicos.Id_medico = txtidMedico.Text;
            oEntMedicos.Nom_medico = txtnombre.Text;
            oEntMedicos.Especialidad = txtespecialidad.Text;
            oEntMedicos.Tel_medico = txttelefono.Text;


            if (oNegMedicos.guardar_medico(oEntMedicos))
            {
                Label5.Text = "Registro guardado........";
            }
            else
            {
                Label5.Text = "Error... Registro NO GUARDADO.......";
            }
        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnanular_Click(object sender, EventArgs e)
        {

        }

        
    }
}