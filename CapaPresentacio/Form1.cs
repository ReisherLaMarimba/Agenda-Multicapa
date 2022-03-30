using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaDatos;
using CapaEntidad;

namespace CapaPresentacio
{
    public partial class Form1 : Form
    {
        private string idcontacto;
        private bool editarse = false;
        Entidad_Contactos objEntidad = new Entidad_Contactos();
        Negocio_Contactos objNegocio = new Negocio_Contactos();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mostrar("");
            accionesEnTabla();
        }
        public void accionesEnTabla()
        {
            ContactView.Columns[0].Visible = false;
            ContactView.ClearSelection();
        }

        private void limpiarCampos()
        {
            editarse = false;
            txt_buscar.Text = "";
            txt_name.Text = "";
            txt_lastname.Text = "";
            txt_cel.Text = "";
            dateTimePicker1.Text = "";
            txt_name.Focus();
        }
        public void Mostrar(string buscar)
        {
            Negocio_Contactos objNegocio = new Negocio_Contactos();
            ContactView.DataSource = objNegocio.ListContacto(buscar);
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            Mostrar(txt_buscar.Text);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (ContactView.SelectedRows.Count > 0)
            {
                editarse = true;
                idcontacto = ContactView.CurrentRow.Cells[0].Value.ToString();
                txt_name.Text = ContactView.CurrentRow.Cells[2].Value.ToString();
                txt_lastname.Text = ContactView.CurrentRow.Cells[3].Value.ToString();
                txt_cel.Text = ContactView.CurrentRow.Cells[5].Value.ToString();
                dateTimePicker1.Text = ContactView.CurrentRow.Cells[4].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar");
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (editarse == false)
            {
                try
                {
                    objEntidad.Nombre = txt_name.Text.ToUpper();
                    objEntidad.Apellido = txt_lastname.Text.ToUpper();
                    objEntidad.Celular = Convert.ToInt32(txt_cel.Text);
                    objEntidad.Apellido = txt_lastname.Text.ToUpper();
                    objEntidad.Fecha_Nacimiento = Convert.ToDateTime( dateTimePicker1.Text);
                    objNegocio.insercionContacto(objEntidad); ;
                    MessageBox.Show("Registro guardado");
                    Mostrar("");
                    limpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar" + ex);
                }
            }
            if (editarse == true)
            {
                try
                {
                    objEntidad.IdContacto= Convert.ToInt32(idcontacto);
                    objEntidad.Nombre = txt_name.Text.ToUpper();
                    objEntidad.Apellido = txt_lastname.Text.ToUpper();
                    objEntidad.Celular = Convert.ToInt32(txt_cel.Text);
                    objEntidad.Apellido = txt_lastname.Text.ToUpper();
                    objEntidad.Fecha_Nacimiento = Convert.ToDateTime(dateTimePicker1.Text);
                    objNegocio.edicionContact(objEntidad);
                    MessageBox.Show("Se edito el registro ");
                    Mostrar("");
                    editarse = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar " + ex);
                }
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (ContactView.SelectedRows.Count > 0)
            {
                objEntidad.IdContacto = Convert.ToInt32(ContactView.CurrentRow.Cells[0].Value.ToString());
                objNegocio.eliminarConta(objEntidad);
                MessageBox.Show("Elimino el registro corectamente");
                Mostrar("");
            }
        }
    }
}
