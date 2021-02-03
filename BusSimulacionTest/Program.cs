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
                    Estacion1(0);
                else
                    Estacion1(desmontaron);

                salir += 1;
            } while (salir < 5);


        }

        static void Estacion1(int desmontaronP) //Metodo que contiene la logica estacion 1
        {
            int cantidadAsientosDisponibles = 0;
            if (desmontaronP > 0)
            {
                Program.desmontaron = GenerarAleatorio(0, 10);
            }

            Console.WriteLine("Entrando a estacion 1" );
            llegando1 = GenerarAleatorio(1, 50);
            esperando1 += llegando1;
            Console.WriteLine("Esperando 1 = "+ Program.esperando1);
            
            Console.WriteLine($"\nEn bus antes de desmontar = {enBus1}");
            Console.WriteLine("\nDesmontaron = " + Program.desmontaron);
            enBus1 = (enBus1 - Program.desmontaron);
            Console.WriteLine("\nDespues de desmontarse en el bus quedan = " + enBus1);

            while (esperando1 < CAPACIDADBUS)
            {
                Console.WriteLine("Entrando a la condicion Ciclo");
                llegando1 = GenerarAleatorio(1, 10); 
                esperando1 += llegando1;
                Console.WriteLine($"Esperando Condicion {esperando1}");
            }

            

            cantidadAsientosDisponibles = (CAPACIDADBUS - enBus1);
            System.Console.WriteLine( "\n Cantidad asientos disponibles= "+cantidadAsientosDisponibles);
            Program.enBus1 = (enBus1 + cantidadAsientosDisponibles);
            Program.esperando1 = (Program.esperando1 - cantidadAsientosDisponibles);
            
            

            //if(desmontaronP)
            //{
            //    Program.esperando1 = (esperando1 - CAPACIDADBUS);
            //}
                
                
            Console.WriteLine($"\nEsperando = {esperando1}");
            //enBus1 = (enBus1 - desmontaron);

            vueltasBus += 1;
            Console.WriteLine("\nCantidad de pasajeros en el bus = "+enBus1);
            Console.WriteLine("\nNumero de vueltas = " + vueltasBus);
            Console.ReadKey();
            

            Console.Clear();
            Console.WriteLine("\nEntrando a estacion 2");
            Estacion2();
            

            
            Console.Clear();
        }

        static void Estacion2() //Metodo que contiene la logica estacion 2
        {
            int cantidadAsientosDisponibles = 0;
            Program.llegando2 = GenerarAleatorio(1,50); // Llegando estacion 2
            Program.esperando2 += Program.llegando2; //Esperando estacion 2

            Console.WriteLine("Estan esperando en la estacion 2 = "+Program.esperando2);
            Console.WriteLine("\nLlegaron en Bus"+enBus1);
            Program.desmontaron = GenerarAleatorio(0, 10);

            Console.WriteLine("\nDesmontaron = "+ Program.desmontaron);
            enBus1 = (enBus1 - Program.desmontaron);
            Console.WriteLine("\nDespues de desmontarse en el bus quedan = "+enBus1);
  
            while (Program.esperando2 < CAPACIDADBUS)
            {
                Console.WriteLine("\nEntrando a la condicion Ciclo");
                Program.llegando2 = GenerarAleatorio(1, 10);
                Program.esperando2 += Program.llegando2;
                Console.WriteLine($"Esperando2 CICLO {Program.esperando2}");
            }

            cantidadAsientosDisponibles = (CAPACIDADBUS - enBus1);
            enBus1 = (enBus1 + cantidadAsientosDisponibles);
            esperando2 = (esperando2 - cantidadAsientosDisponibles);

  
            Console.WriteLine($"\nCantidad asientos = {cantidadAsientosDisponibles}" );
            Console.WriteLine("\nNuevo bus = "+ enBus1);
            Console.WriteLine("\nQuedaron esperando: "+esperando2);

            
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
