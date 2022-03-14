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
    public partial class Buscar : Form
    {
        private List<Empleado> listado = new List<Empleado>();
        public Buscar()
        {
            InitializeComponent();
        }

        public Buscar(List<Empleado> listEmp)
        {
            InitializeComponent();
            foreach (var item in listEmp)
            {
                comboBox1.Items.Add(item.Cedula);
            }
            this.listado = listEmp;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            String cedula = comboBox1.SelectedItem.ToString();
            foreach (var item in listado)
            {
                if (cedula == item.Cedula)
                {
                    txtbasico.Text = item.BaseEmp.ToString();
                    txtaux_trans.Text = item.AuxTransporte.ToString();
                    txtcajas.Text = item.CajaCompensacion.ToString();
                    txtcedula.Text = item.Cedula.ToString();
                    txtcesantias.Text = item.Cesantias.ToString();
                    txtdias.Text = item.Dtrabajados.ToString();
                    txtfondosolidario.Text = item.FondoSol.ToString();
                    txthorasextrasDiu.Text = item.HED.ToString();
                    txthorasextraNoc.Text = item.HEN.ToString();
                    txthorasextrasdominicalesDiu.Text = item.HEDD.ToString();
                    txthorasextrasdominicalesNoc.Text = item.HEDN.ToString();
                    txticbf.Text = item.Icbf.ToString();
                    txtintycesan.Text = item.Cesantias.ToString();
                    txtnivelderiesgo.Text = item.Nriesgo.ToString();
                    txtnombre.Text = item.NombreEmpleado.ToString();
                    txtpension_emp.Text = item.Pension.ToString();
                    txtpension_pat.Text = item.PensionPatron.ToString();
                    txtprima.Text = item.Prima.ToString();
                    txtrecargosnocturnos.Text = item.RECNOC.ToString();
                    txtretefuente.Text = item.TotalRetefuente.ToString();
                    txtretepesos.Text = item.Retencion.ToString();
                    txtsalud_emp.Text = item.Salud.ToString();
                    txtsalud_pat.Text = item.SaludPatron.ToString();
                    txtsena.Text = item.Sena.ToString();
                    txtsueldo.Text = item.Sueldo.ToString();
                    txttotaldevengado.Text = item.TotalDevengado.ToString();
                    txttotalextras.Text = item.Total.ToString();
                    txttotalnomina.Text = item.Totalbasico.ToString();
                    txttotal_deducido.Text = item.Deducidos.ToString();
                    txttotal_para.Text = item.BaseEmp.ToString();
                    txttotal_presta.Text = item.Prestaciones.ToString();
                    txtuvt.Text = item.UVT.ToString();
                    txtvacaciones.Text = item.Vacaciones.ToString();
                    txtarl.Text = item.Arl.ToString();
                   




                    break;
                }
            }

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtsalud_emp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
