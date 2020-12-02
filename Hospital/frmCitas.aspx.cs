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
    public partial class frmCitas : System.Web.UI.Page
   
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

            txtCita.Text = "";
            txtFecha.Text ="";
            txtHora.Text = "";
            txtPaciente.Text ="";
            txtMedico.Text ="";
            txtConsulta.Text ="";
            txtDiagnostico.Text ="";
            txtAcompañante.Text = "";
            Label3.Text = "";
            Label1.Text = "";
            Label4.Text = "";




        }



        protected void btnConfirmarCita_Click(object sender, EventArgs e)
        {
            if (txtCita.Text == "")
            {
                Label3.Text = "No se ha ingresado ningun codigo de cita";
                txtCita.Focus();
            }
            else
            {
                DataSet ds = new DataSet();
                oEntCitas.Cod_cita = txtCita.Text;
                ds = oNegCitas.consultar_cita(oEntCitas);

                if(ds.Tables[0].Rows.Count == 0)
                {
                    Label3.Text = "El codigo esta disponible para asignar cita";
                    txtFecha.Focus();

                }
                else
                {
                    txtFecha.Text = ds.Tables[0].Rows[0]["fecha"].ToString();
                    txtHora.Text = ds.Tables[0].Rows[0]["hora"].ToString();
                    txtPaciente.Text = ds.Tables[0].Rows[0]["Id_paciente"].ToString();
                    txtMedico.Text = ds.Tables[0].Rows[0]["id_medico"].ToString();
                    txtConsulta.Text = ds.Tables[0].Rows[0]["valor"].ToString();
                    txtDiagnostico.Text = ds.Tables[0].Rows[0]["diagnostico"].ToString();
                    txtAcompañante.Text = ds.Tables[0].Rows[0]["Nom_acompanante"].ToString();

                }
            }
            
        }

        protected void btnGuardarCita_Click(object sender, EventArgs e)
        {
            oEntCitas.Cod_cita = txtCita.Text;
            oEntCitas.Fecha = Convert.ToDateTime(txtFecha.Text);
            oEntCitas.Hora = Convert.ToDateTime(txtHora.Text);
            oEntCitas.Id_paciente1 = txtPaciente.Text;
            oEntCitas.Id_medico = txtMedico.Text;
            oEntCitas.Valor = Convert.ToInt32(txtConsulta.Text);
            oEntCitas.Diagnostico = txtDiagnostico.Text;
            oEntCitas.Nom_acompanante1 = txtAcompañante.Text;

            if (oNegCitas.guardar_cita(oEntCitas))
            {
                Label3.Text = "Registro guardado........";
            }
            else
            {
                Label3.Text = "Error... Registro NO GUARDADO.......";
            }    


        }

        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {

            if (txtPaciente.Text == "")
            {
                Label1.Text = "No se ha ingresado ningun codigo de paciente";
                txtPaciente.Focus();
            }
            else
            {
                DataSet ds = new DataSet();
                oEntPacientes.Id_paciente1 = txtPaciente.Text;
                ds = oNegPacientes.consultar_paciente(oEntPacientes);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    Label1.Text = "El codigo de paciente no existe";
                    txtPaciente.Focus();

                }
                else
                {
                    Label1.Text = ds.Tables[0].Rows[0]["nom_paciente"].ToString();


                }
            }
        }

        protected void btnBuscarMedico_Click(object sender, EventArgs e)
        {

            if (txtMedico.Text == "")
            {
                Label4.Text = "No se ha ingresado ningun codigo de medico";
                txtMedico.Focus();
            }
            else
            {
                DataSet ds = new DataSet();
                oEntMedicos.Id_medico = txtMedico.Text;
                ds = oNegMedicos.consultar_medico(oEntMedicos);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    Label4.Text = "El codigo de medico no existe";
                    txtMedico.Focus();

                }
                else
                {

                    Label4.Text = ds.Tables[0].Rows[0]["nom_medico"].ToString();


                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}