using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace ProyectoBusGrafico
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //CAMPOS DE LA CLASE
        public const int CAPACIDADBUS = 10;

        //Estacion1 
        public static int esperando1 { get; set; } = 0;
        public static int llegando1 { get; set; } = 0;

        //Estacion 2
        public static int entrada2 { get; set; }
        public static int estacion2 { get; set; }
        public static int esperando2 { get; set; }
        public static int llegando2 { get; set; }

        public static int montaron { get; set; }
        public static int desmontaron { get; set; } = 0;

        //Componente Bus
        public static int enBus1 { get; set; } = 10;
        public static int vueltasBus { get; set; }

        void Estacion1(int desmontaronP) //Metodo que contiene la logica estacion 1
        {
            int cantidadAsientosDisponibles = 0;
            if (desmontaronP > 0)
            {
                desmontaron = GenerarAleatorio(0, 10);
            }

            EntrandoE1.Text=("Entrando a estacion 1");
            llegando1 = GenerarAleatorio(1, 50);
            esperando1 += llegando1;
            EsperandoE1.Text=("" + esperando1);

            AntesEnbus1.Text=(""+ enBus1);
            Desmontando1.Text=(" " + desmontaron);
            enBus1 = (enBus1 - desmontaron);
            Despuesdedesmontarseenelbusquedan1.Text=(" " + enBus1);

            while (esperando1 < CAPACIDADBUS)
            {
                llegando1 = GenerarAleatorio(1, 10);
                esperando1 += llegando1;
            }

            cantidadAsientosDisponibles = (CAPACIDADBUS - enBus1);
            System.Console.WriteLine("\n Cantidad asientos disponibles= " + cantidadAsientosDisponibles);
            enBus1 = (enBus1 + cantidadAsientosDisponibles);
            esperando1 = (esperando1 - cantidadAsientosDisponibles);


            Nesperando1.Text=(""+ esperando1);

            vueltasBus += 1;
            NuevasPersonasEnbus.Text=("" + enBus1);
            Nvueltas1.Text=("" + vueltasBus);

            Tiempo1.Text = ""+GenerarAleatorio(15, 20);

            EntrandoE2.Text=("Entrando a estacion 2");
            Estacion2();

        }

        void Estacion2() //Metodo que contiene la logica estacion 2
        {
            int cantidadAsientosDisponibles = 0;
            llegando2 = GenerarAleatorio(1, 50); // Llegando estacion 2
            esperando2 += llegando2; //Esperando estacion 2

            EsperandoE2.Text=("" + esperando2);
            Enbus1_Copy.Text=("" + enBus1);
            desmontaron = GenerarAleatorio(0, 10);

            Desmontando2.Text=(" " + desmontaron);
            enBus1 = (enBus1 - desmontaron);
            Despuesdedesmontarseenelbusquedan2.Text=("" + enBus1);

            while (esperando2 < CAPACIDADBUS)
            {
                llegando2 = GenerarAleatorio(1, 10);
                esperando2 += llegando2;
            }

            cantidadAsientosDisponibles = (CAPACIDADBUS - enBus1);
            enBus1 = (enBus1 + cantidadAsientosDisponibles);
            esperando2 = (esperando2 - cantidadAsientosDisponibles);
            
            NuevasPersonasEnbus_Copy.Text=(" " + enBus1);
            Nesperando2.Text = (" " + esperando2);


            Nvueltas2.Text=("" + vueltasBus);
            Tiempo2.Text = "" + GenerarAleatorio(15, 20);

        }


        static int GenerarAleatorio(int min, int max) //Generador metodos aleatorios 
        {
            Random random = new Random();
            int aleatorio = random.Next(min, max);

            return aleatorio;
        }

        static double Pi(int min, int max)
        {
            return 0;
        }

        static double Kon(int min, int max)
        {
            return 0;
        }

        public MainWindow()
        {
            InitializeComponent();
                       
        }

        private void Iniciar_Click(object sender, RoutedEventArgs e)
        {
                if (vueltasBus <= 0)
                {
                    Estacion1(0);
                    Thread.Sleep(1000);
                }
                else
                   Estacion1(desmontaron);
                    Thread.Sleep(1000);
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
