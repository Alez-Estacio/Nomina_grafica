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
    public partial class Principal : Form
    {
        public List<Empleado> listaEmpleados;
        
        public void addEmpleado(Empleado emp)
        {
            listaEmpleados.Add(emp);
        }

        public Empleado getEmpleado()
        {
            return new Empleado();
        }


        public Principal()
        {
            InitializeComponent();
            listaEmpleados = new List<Empleado>();
            dgwNomina.AutoGenerateColumns = true;
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            Form frAgregar = new Agregar(this);
            
            frAgregar.Show();
            
             
        }

        public void refeshDataGridView()
        {

            BindingList<Empleado> bindLs = new BindingList<Empleado>(listaEmpleados);
            BindingSource source = new BindingSource(bindLs, null);
            dgwNomina.DataSource = source;
            dgwNomina.AutoGenerateColumns = true;

            dgwNomina.Refresh();
            
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            listaEmpleados.Clear();
            refeshDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Buscar(listaEmpleados).Show();
            
        }

        private void dgwNomina_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
