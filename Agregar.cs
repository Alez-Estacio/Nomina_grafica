using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NOMINA2021
{
    public partial class Agregar : Form
    {
        public Principal FormularioAnterior = new Principal();

        public Agregar()
        {
            InitializeComponent();
        }

        public Agregar(Principal parentForm)
        {
            InitializeComponent();
            FormularioAnterior = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Empleado emp = new Empleado();
            emp.NombreEmpleado = txtnombre.Text;
            emp.Cedula = txtcedula.Text;
            emp.Sueldo = Double.Parse(txtsueldo.Text);
            emp.Dtrabajados = Int32.Parse(txtdias.Text);
            emp.HED = Int32.Parse(txthorasextradiurnas.Text);
            emp.HEN = Int32.Parse(txtextranocturna.Text);
            emp.HEDD = Int32.Parse(horasextradominicalesN.Text);
            emp.HEDN = Int32.Parse(horasextradominicalesN.Text);
            emp.RECNOC = Int32.Parse(txtrecargosnocturnos.Text);
            emp.Nriesgo = Int32.Parse(listRiesgo.SelectedItem.ToString());
            emp.calcularNomina();
            FormularioAnterior.addEmpleado(emp);
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            txtcedula.Clear();
            txtnombre.Clear();
            txtdias.Clear();
            txtsueldo.Clear();
            txthorasextradiurnas.Clear();
            txtextranocturna.Clear();
            horasextradominicalesD.Clear();
            horasextradominicalesN.Clear();
            txtrecargosnocturnos.Clear();
            listRiesgo.ClearSelected();
            
        }

        private void txtcedula_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void Agregar_Load(object sender, EventArgs e)
        {
            FormularioAnterior.refeshDataGridView();
        }
    }
}
