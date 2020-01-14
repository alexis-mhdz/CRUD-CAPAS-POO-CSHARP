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
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class FormEmpleado : Form
    {
        private string id;
        private bool editarse = false;

        private E_Empleado objetoEntidad = new E_Empleado();
        private N_Empleado objetoNegocio = new N_Empleado();
        public FormEmpleado()
        {
            InitializeComponent();
        }

        private void FormEmpleado_Load(object sender, EventArgs e)
        {
            ActualizarTabla("");
            EstilosTabla();
        }

        // Metodos.

        private void ActualizarTabla(string buscar)
        {
            N_Empleado objetoNegocio = new N_Empleado();
            dataGridViewTable.DataSource = objetoNegocio.ListandoEmpleados(buscar);
        }

        private void EstilosTabla()
        {
            dataGridViewTable.Columns[0].Visible = false;
            dataGridViewTable.ClearSelection();
        }

        private void LimpiarCajas()
        {
            editarse = false;
            textBoxFolio.Clear();
            textBoxNombre.Clear();
            textBoxApellidos.Clear();
            comboBoxSexo.SelectedIndex = 0;
            dateTimePickerFechaNacimiento.Value = DateTime.Today;
            textBoxPuesto.Clear();
            textBoxSueldo.Clear();
            textBoxNombre.Focus();
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarTabla(textBoxBuscar.Text);
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCajas();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if(dataGridViewTable.SelectedRows.Count == 1)
            {
                id = dataGridViewTable.CurrentRow.Cells[0].Value.ToString();
                textBoxFolio.Text = dataGridViewTable.CurrentRow.Cells[1].Value.ToString();
                textBoxNombre.Text = dataGridViewTable.CurrentRow.Cells[2].Value.ToString();
                textBoxApellidos.Text = dataGridViewTable.CurrentRow.Cells[3].Value.ToString();
                comboBoxSexo.SelectedItem = dataGridViewTable.CurrentRow.Cells[4].Value;
                dateTimePickerFechaNacimiento.Value = Convert.ToDateTime(dataGridViewTable.CurrentRow.Cells[5].Value);
                textBoxPuesto.Text = dataGridViewTable.CurrentRow.Cells[6].Value.ToString();
                textBoxSueldo.Text = dataGridViewTable.CurrentRow.Cells[7].Value.ToString();
                textBoxNombre.Focus();
                editarse = true;
            }
            else
            {
                MessageBox.Show("Selecciona la fila que deseas editar");
            }
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            if(editarse == false)
            {
                try
                {
                    objetoEntidad.Nombre = textBoxNombre.Text;
                    objetoEntidad.Apellidos = textBoxApellidos.Text;
                    objetoEntidad.Sexo = comboBoxSexo.Text;
                    objetoEntidad.FechaNacimiento = dateTimePickerFechaNacimiento.Value;
                    objetoEntidad.Puesto = textBoxPuesto.Text;
                    objetoEntidad.Sueldo = Convert.ToDecimal(textBoxSueldo.Text);

                    objetoNegocio.InsertandoEmpleado(objetoEntidad);

                    MessageBox.Show("Registro guardado");
                    ActualizarTabla("");
                    LimpiarCajas();
                } catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el registro. " + ex);
                }
            } else if(editarse == true)
            {
                try
                {
                    objetoEntidad.Id = Convert.ToInt32(id);
                    objetoEntidad.Nombre = textBoxNombre.Text;
                    objetoEntidad.Apellidos = textBoxApellidos.Text;
                    objetoEntidad.Sexo = comboBoxSexo.Text;
                    objetoEntidad.FechaNacimiento = dateTimePickerFechaNacimiento.Value;
                    objetoEntidad.Puesto = textBoxPuesto.Text;
                    objetoEntidad.Sueldo = Convert.ToDecimal(textBoxSueldo.Text);

                    objetoNegocio.EditandoEmpleado(objetoEntidad);

                    MessageBox.Show("Registro editado");
                    ActualizarTabla("");
                    LimpiarCajas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar la edición el registro. " + ex);
                }
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if(dataGridViewTable.SelectedRows.Count == 1)
            {
                objetoEntidad.Id = Convert.ToInt32(dataGridViewTable.CurrentRow.Cells[0].Value.ToString());
                objetoNegocio.EliminadoEmpleado(objetoEntidad);
                ActualizarTabla("");


                MessageBox.Show("Registro eliminado correctamente");

            } else
            {
                MessageBox.Show("Selecciona la fila a eliminar");
            }
        }
    }
}
