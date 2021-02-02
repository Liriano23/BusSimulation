using System;

namespace BusSimulacionTest
{
    class Program
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
        


        static void Main(string[] args)
        {

            int salir = 0;
            //double tiempo = 0.0; // Tiempo promedio en llegada 

            do
            {
                if (vueltasBus <= 0)
                    Estacion1(enBus1, 0);
                else
                    Estacion1(enBus1, desmontaron);

                salir += 1;
            } while (salir < 3);


        }

        static void Estacion1(int enBus, int desmontaron) //Metodo que contiene la logica estacion 1
        {
            Console.WriteLine("Entrando a estacion 1" );
            llegando1 = GenerarAleatorio(1, 50);
            esperando1 += llegando1;
            Console.WriteLine("Esperando 1 = "+ Program.esperando1);
            int cantidadAsientosDisponibles = 0;

            Console.WriteLine("\nDesmontaron = " + Program.desmontaron);
            Console.WriteLine($"\nEn bus antes de desmontar = {enBus1}");
            enBus = (enBus - desmontaron);
            Console.WriteLine("\nDespues de desmontarse en el bus quedan = " + enBus);

            while (esperando1 < CAPACIDADBUS)
            {
                Console.WriteLine("Entrando a la condicion Ciclo");
                llegando1 = GenerarAleatorio(1, 10); 
                esperando1 += llegando1;
                Console.WriteLine($"Esperando Condicion {esperando1}");
            }

            
            cantidadAsientosDisponibles =  (Program.CAPACIDADBUS - enBus);
            Program.enBus1 = (enBus + cantidadAsientosDisponibles);
            Program.esperando1 = (Program.esperando1 - cantidadAsientosDisponibles);


   
            Console.WriteLine($"\nEsperando = {esperando1}");
            enBus1 = (enBus - desmontaron);
            vueltasBus += 1;

            Console.WriteLine("\nCantidad de pasajeros en el bus = "+enBus1);
            Console.WriteLine("\nNumero de vueltas = " + vueltasBus);
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("\nEntrando a estacion 2");
            Estacion2(enBus1);


            
            Console.Clear();
        }

        static void Estacion2(int enBus) //Metodo que contiene la logica estacion 2
        {
            int cantidadAsientosDisponibles = 0;
            Program.llegando2 = GenerarAleatorio(1,50); // Llegando estacion 2
            Program.esperando2 += Program.llegando2; //Esperando estacion 2

            Console.WriteLine("Estan esperando en la estacion 2 = "+Program.esperando2);
            Console.WriteLine("\nLlegaron en Bus"+enBus);
            Program.desmontaron = GenerarAleatorio(0, 10);

            Console.WriteLine("\nDesmontaron = "+ Program.desmontaron);
            enBus = (enBus - desmontaron);
            Console.WriteLine("\nDespues de desmontarse en el bus quedan = "+enBus);
  
            while (Program.esperando2 < CAPACIDADBUS)
            {
                Console.WriteLine("\nEntrando a la condicion Ciclo");
                Program.llegando2 = GenerarAleatorio(1, 10);
                Program.esperando2 += Program.llegando2;
                Console.WriteLine($"Esperando2 CICLO {Program.esperando2}");
            }

            cantidadAsientosDisponibles = (CAPACIDADBUS - enBus);
            enBus1 = (enBus + cantidadAsientosDisponibles);
            esperando2 = (esperando2 - cantidadAsientosDisponibles);

  
            Console.WriteLine($"\nCantidad asientos = {cantidadAsientosDisponibles}" );
            Console.WriteLine("\nNuevo bus = "+ enBus1);
            Console.WriteLine("\nQuedaron esperando: "+esperando2);

            vueltasBus += 1;
            Console.WriteLine("Numero de vueltas = "+vueltasBus);


            Console.ReadKey();
            Console.Clear();
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
    }
}
