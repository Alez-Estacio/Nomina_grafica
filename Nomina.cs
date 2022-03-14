using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOMINA2021
{

	public class Empleado
	{
		private const double SMLV = 908256;
		private const double auxtrans = 106454;
		private const double uUvt = 36308;


        private string cedula;
        private double sueldo;
        private int dtrabajados;
        private int hED;
        private int hEN;
        private int hEDD;
        private int hEDN;
        private int rECNOC;
        private int nriesgo;

        private Double totalDevengado;
        private Double deducidos;
        private Double totalparafiscales;
        private Double total;
        private string nombreEmpleado;
        private double totalbasico;
        private double auxTransporte;
        private double horasExtras;
        private double salud;
        private double pension;
        private double baseEmp;
        private double fondoSol;
        private double uVT;
        private double retencion;
        private double totalRetefuente;
        private double saludPatron;
        private double pensionPatron;
        private double arl;
        private double sena;
        private double icbf;
        private double cajaCompensacion;
        private double cesantias;
        private double interes;
        private double prima;
        private double vacaciones;
        private double prestaciones;

        public string NombreEmpleado { get => NombreEmpleado1; set => NombreEmpleado1 = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public double Sueldo { get => sueldo; set => sueldo = value; }
        public int Dtrabajados { get => dtrabajados; set => dtrabajados = value; }
        public int HED { get => hED; set => hED = value; }
        public int HEN { get => hEN; set => hEN = value; }
        public int HEDD { get => hEDD; set => hEDD = value; }
        public int HEDN { get => hEDN; set => hEDN = value; }
        public int RECNOC { get => rECNOC; set => rECNOC = value; }
        public int Nriesgo { get => nriesgo; set => nriesgo = value; }
        public double Totalbasico { get => totalbasico; set => totalbasico = value; }
        public double AuxTransporte { get => auxTransporte; set => auxTransporte = value; }
        public double HorasExtras { get => horasExtras; set => horasExtras = value; }
        public double TotalDevengado { get => totalDevengado; set => totalDevengado = value; }
        public double Salud { get => salud; set => salud = value; }
        public double Pension { get => pension; set => pension = value; }
        public double BaseEmp { get => baseEmp; set => baseEmp = value; }
        public double FondoSol { get => fondoSol; set => fondoSol = value; }
        public double UVT { get => uVT; set => uVT = value; }
        public double Retencion { get => retencion; set => retencion = value; }
        public double TotalRetefuente { get => totalRetefuente; set => totalRetefuente = value; }
        public double Deducidos { get => deducidos; set => deducidos = value; }
        public double SaludPatron { get => saludPatron; set => saludPatron = value; }
        public double PensionPatron { get => pensionPatron; set => pensionPatron = value; }
        public double Arl { get => arl; set => arl = value; }
        public double Sena { get => sena; set => sena = value; }
        public double Icbf { get => icbf; set => icbf = value; }
        public double CajaCompensacion { get => cajaCompensacion; set => cajaCompensacion = value; }
        public double Totalparafiscales { get => totalparafiscales; set => totalparafiscales = value; }
        public double Cesantias { get => cesantias; set => cesantias = value; }
        public double Interes { get => interes; set => interes = value; }
        public double Prima { get => prima; set => prima = value; }
        public double Vacaciones { get => vacaciones; set => vacaciones = value; }
        public double Prestaciones { get => prestaciones; set => prestaciones = value; }
        public double Total { get => total; set => total = value; }
        public string NombreEmpleado1 { get => nombreEmpleado; set => nombreEmpleado = value; }

        public Empleado()
		{
			NombreEmpleado = "";
			Cedula = "";
			Sueldo = SMLV;
			HED = HEDD = HEDN = RECNOC = Nriesgo = 0;
		}

		// Claculo cueldo básico
		private double calculoSueldoBasico()
		{
			double basico;
			basico = Sueldo * Dtrabajados / 30;
			basico = Math.Ceiling(basico);
			return basico;
		}


		//Auxilio de Transporte
		private double calculoAuxilioTransporte()
		{
			if (Sueldo <= (2 * SMLV))
			{
				double ttrans;
				ttrans = (auxtrans / 30) * Dtrabajados;
				ttrans = Math.Ceiling(ttrans);
				return ttrans;
			}
			else
				return 0;
		}

		//Horas Extras
		private double calculoHorasExtras()
		{
			double hordinaria, thoras;
			hordinaria = Sueldo / 240;
			hordinaria = Math.Ceiling(hordinaria);
			thoras = (hordinaria * HED * 0.0125 * 100) + (hordinaria * HEN * 0.0175 * 100) + (hordinaria * HEDD * 0.02 * 100) + (hordinaria * HEDN * 0.025 * 100) + (hordinaria * RECNOC * 0.0035 * 100);
			thoras = Math.Ceiling(thoras);
			return thoras;
		}


		// Calculo sueldo devengado
		private double calculoDevengado()
		{
			return calculoSueldoBasico() + calculoHorasExtras() + calculoAuxilioTransporte();
		}

		//Deducidos - Salud
		private double calculoSalud()
		{
			double saludemp = (calculoSueldoBasico() + calculoHorasExtras()) * 0.04;
			return saludemp;
		}

		//Deducidos - Pensión
		private double calculoPension()
		{
			double pensionemp = (calculoSueldoBasico() + calculoHorasExtras()) * 0.04;
			return pensionemp;
		}

		// calculo fondo solidario pensional
		private double calculoFondoSolidadridad()
		{
			double sbase, fondosol;
			fondosol = 0;
			sbase = calculoSueldoBasico() + calculoHorasExtras();
			// Sacar cuantos salarios minimos vigente gana
			int SolP = (Convert.ToInt32(sbase / SMLV));

			if (SolP >= 4 && SolP < 16)
			{
				fondosol = (sbase * 1) / 100;
			}
			else
			{
				if (SolP >= 16 && SolP <= 17)
				{
					fondosol = (sbase * 1.20) / 100;
				}
				else if (SolP > 17 && SolP <= 18)
				{
					fondosol = (sbase * 1.40) / 100;
				}
				else if (SolP > 18 && SolP <= 19)
				{
					fondosol = (sbase * 1.60) / 100;
				}
				else if (SolP > 19 && SolP <= 20)
				{
					fondosol = (sbase * 1.80) / 100;
				}
				else if (SolP > 20)
				{
					fondosol = (sbase * 2) / 100;
				}
				fondosol = Math.Ceiling(fondosol);
			}
			return fondosol;
		}


		//Calculo UVT
		private double calculoUVT()
		{
			double UVT;
			UVT = (((calculoDevengado() - calculoSalud() - calculoPension() - calculoFondoSolidadridad()) * 75) / 100) / uUvt;
			return UVT;
		}

		//calculo retefuente
		private double calculoRetefuente()
		{
			double sbase, UVT;
			sbase = calculoSueldoBasico() + calculoHorasExtras();
			UVT = calculoUVT();
			double uvtC = (Convert.ToDouble(sbase / uUvt));
			double retefuente = 0;

			if (uvtC >= 2300)
			{
				retefuente = ((UVT - 2300) * 39 / 100 + 770);
			}
			else
			{
				if (uvtC > 945 && uvtC <= 2300)
				{
					retefuente = ((UVT - 945) * 37 / 100 + 268);
				}
				else if (uvtC >= 640 && uvtC <= 945)
				{
					retefuente = ((UVT - 640) * 35 / 100 + 162);
				}
				else if (uvtC > 360 && uvtC <= 640)
				{
					retefuente = ((UVT - 360) * 33 / 100 + 69);
				}
				else if (uvtC > 150 && uvtC <= 360)
				{
					retefuente = ((UVT - 150) * 28 / 100 + 10);
				}
				else if (uvtC > 95 && uvtC <= 150)
				{
					retefuente = ((UVT - 95) * 19) / 100;
				}
			}

			return retefuente;
		}


		//Total de retefuente
		private double calculoTotalRetefuente()
		{
			return calculoRetefuente() * uUvt;
		}


		// Total deducido
		private double calculoTotalDeducido()
		{
			double tdeducido = calculoSalud() + calculoPension() + calculoFondoSolidadridad() + calculoUVT() + calculoTotalRetefuente();
			tdeducido = Math.Ceiling(tdeducido);
			return tdeducido;
		}

		private double calculoBase()
		{
			return calculoSueldoBasico() + calculoHorasExtras();
		}

		//----------------- CALCULO TOTAL PARAFISCALES-----------------------------
		// calculo salud patron
		private double calculoPasafiscalesSaludPatron()
		{
			double saludpat;
			double sbase;
			sbase = calculoBase();
			saludpat = (sbase * 8.5) / 100;
			return saludpat;
		}

		// calculo pension patron
		private double calculoPasafiscalesPensionPatron()
		{
			double pensionpat;
			double sbase;
			sbase = calculoBase();
			pensionpat = (sbase * 12) / 100;
			return pensionpat;
		}

		//calculo arl segun nivel de riesgo
		private double calculoARL()
		{
			double arl = 0;
			double sbase;
			sbase = calculoBase();
			switch (Nriesgo)
			{
				case 1:
					arl = (sbase * 0.522) / 100;
					break;
				case 2:
					arl = (sbase * 1.044) / 100;
					break;
				case 3:
					arl = (sbase * 2.436) / 100;
					break;
				case 4:
					arl = (sbase * 4.350) / 100;
					break;
				case 5:
					arl = (sbase * 6.960) / 100;
					break;
			}
			return arl;
		}


		//------ calcula SENA
		private double calculoSena()
		{
			double sena, sbase;
			sbase = calculoBase();
			sena = (sbase * 2) / 100;
			return sena;
		}


		//----- calcula  ICBF
		private double calculoICBF()
		{
			double icbf, sbase;
			sbase = calculoBase();
			icbf = (sbase * 3) / 100;
			return icbf;
		}


		//----- calcula  caja de compensacion
		private double calculoCajaCompensacion()
		{
			double caja;
			caja = (calculoDevengado() * 4) / 100;
			return caja;
		}


		// total de paraficales
		private double calculoTotalPasafiscales()
		{
			double tparafiscales;
			tparafiscales = calculoPasafiscalesSaludPatron() + calculoPasafiscalesPensionPatron() + calculoARL() + calculoSena() + calculoICBF() + calculoCajaCompensacion();
			tparafiscales = Math.Ceiling(tparafiscales);
			return tparafiscales;
		}


		//------- calcula prestaciones ------

		// -- calculo  cesantias
		private double calculoCesantias()
		{
			double cesantias;
			cesantias = (calculoDevengado() * 8.33) / 100;
			return cesantias;
		}

		//-- calcula interes cesantias
		private double calculoInteresCesantias()
		{
			double incesantias;
			incesantias = (calculoCesantias() * 1) / 100;
			return incesantias;
		}

		//-- calcula prima
		private double calculoPrima()
		{
			double prima;
			prima = (calculoDevengado() * 8.33) / 100;
			return prima;
		}


		// calcula valor de las vacaciones 
		private double calculoVacaciones()
		{
			double vacaciones, sbase;
			sbase = calculoBase();
			vacaciones = (sbase * 4.17) / 100;
			return vacaciones;
		}

		//------- calcular total prestaciones legales
		private double calculoTotalPrestaciones()
		{
			double tprestaciones;
			tprestaciones = calculoCesantias() + calculoInteresCesantias() + calculoPrima() + calculoVacaciones();
			return tprestaciones;
		}


		//-------------- calcular total nomina
		private double calculoTotalNomina()
		{
			double tNomina;
			tNomina = calculoDevengado() - calculoTotalDeducido() + calculoTotalPasafiscales() + calculoTotalPrestaciones();
			tNomina = Math.Ceiling(tNomina);
			return tNomina;
		}

	
		public void calcularNomina()
		{
	
			Totalbasico = calculoSueldoBasico();
			//calculo auxilio de transporte

			AuxTransporte = calculoAuxilioTransporte();

			HorasExtras = calculoHorasExtras();
			// calculo total devengado

			TotalDevengado = calculoDevengado();

			//-------------------CALCULO DEDUCIDOS--------------------------------------------------------

			Salud = calculoSalud();


			Pension = calculoPension();

			BaseEmp = calculoBase();

			// calculo fondo solidario pensional
			// Sacar cuantos salarios minimos vigente gana

			FondoSol = calculoFondoSolidadridad();


			UVT= calculoUVT();
			// calculo valor retefuente 
			//sacar cantidad de uvt

			Retencion= calculoRetefuente();


			// calculo valor a pagar retefuente
			TotalRetefuente= calculoTotalRetefuente();

			Deducidos= calculoTotalDeducido();

			//----------------- CALCULO TOTAL PARAFISCALES-----------------------------
			// calculo salud patron

			SaludPatron = calculoPasafiscalesSaludPatron();
			// calculo pension patron


			PensionPatron= calculoPasafiscalesPensionPatron();
			//calculo arl segun nivel de riesgo


			Arl= calculoARL();

			//------ calcula SENA

			Sena= calculoSena();

			//----- calcula  ICBF

			Icbf= calculoICBF();

			//----- calcula  caja de compensacion

			CajaCompensacion= calculoCajaCompensacion();


			Totalparafiscales= calculoTotalPasafiscales();
			//------- calcula prestaciones ------

			// -- calculo  cesantias

			Cesantias= calculoInteresCesantias();

			//-- calcula interes cesantias

			Interes= calculoInteresCesantias();

			//-- calcula prima

			Prima= calculoPrima();

			// calcula valor de las vacaciones 

			Vacaciones= calculoVacaciones();

			//------- calcular total prestaciones legales


			Prestaciones= calculoTotalPrestaciones();

			//-------------- calcular total nomina


			Total= calculoTotalNomina();



			
		}


    }
}
