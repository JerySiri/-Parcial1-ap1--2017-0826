using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial1_ap1_2017_0826.Entidades;
using Parcial1_ap1_2017_0826.BLL;

namespace Parcial1_ap1_2017_0826
{
    public partial class rCiudades : Form
    {
        public rCiudades()
        {
            InitializeComponent();
        }

        private Ciudad llenarclase()
        {
            Ciudad ciudad = new Ciudad();

            ciudad.CiudadId =(int) IdCiudadNumericUpDown.Value;
            ciudad.Nombre = NombreTextBox.Text;

            return ciudad;
        }
        private void limpiar()
        {
            IdCiudadNumericUpDown.Value = 0;
            NombreTextBox.Clear();
        }

        private void llenarcampo(Ciudad ciudad)
        {
            IdCiudadNumericUpDown.Value = ciudad.CiudadId;
            NombreTextBox.Text = ciudad.Nombre;
        }

        private bool existeEnBaseDeDatos()
        {
            Ciudad ciudad = CiudadBLL.buscar((int)IdCiudadNumericUpDown.Value);
            return (ciudad != null);
        }

        private void rCiudades_Load(object sender, EventArgs e)
        {

        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Ciudad ciudad;
            bool paso = false;

            if (!validar())
                return;

            ciudad = llenarclase();

            if (CiudadBLL.existeNombre(NombreTextBox.Text))
            {
                paso = CiudadBLL.guardar(ciudad);
            }
            else
            {
                MessageBox.Show("Nombre repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            

            if (paso)
            {
                limpiar();
                MessageBox.Show("Accion realizada con exito!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
                MessageBox.Show("No se pudo realizar la accion!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if(NombreTextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(NombreTextBox, "El campo no puede estar Vacio.");
                NombreTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            limpiar();

            Ciudad ciudad = new Ciudad();
            ciudad = CiudadBLL.buscar((int)IdCiudadNumericUpDown.Value);

            if (ciudad != null)
            {
                limpiar();
                MessageBox.Show("Accion realizada con exito!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo realizar la accion!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (CiudadBLL.eliminar((int)IdCiudadNumericUpDown.Value))
            {
                limpiar();
                MessageBox.Show("Accion realizada con exito!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo realizar la accion!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
