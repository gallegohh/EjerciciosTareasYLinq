using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            Tareas tareas = new Tareas();
            tareas.MetodoPrincipal();
            Console.ReadKey();
        }
    }

    public class Tareas
    {
        public void MetodoPrincipal()
        {
            MetodoAsincronoAsync();
            MetodoNormal();
        }

        public async void MetodoAsincronoAsync()
        {
            Task<int> tareaSuma = Task.Run<int>(() =>
            {
                int i = 0;
                for (i = 0; i < 15; i++)
                {

                }

                return i;
            });

            var numero = await tareaSuma;
            // Creación de Tarea 1
            Task<bool> tarea1 = new Task<bool>(()=>
            {
                Console.WriteLine("Vamos a contar del 0 al 60");
                for (int i = 0; i <= 60; i++)
                {
                    Console.WriteLine("Tarea 1 dice {0}",i);
                    // Espera un segundo
                    Thread.Sleep(1000);
                }
                return true;
            });
            // Ejecución de Tarea 1
            tarea1.Start();
            // Creación y ejecución de Tarea 2
            Task tarea2 = Task.Run(() =>
            {
                for (int i = 100; i <= 160; i++)
                {
                    Console.WriteLine("Tarea 2 dice {0}",i);
                }
            });

            Task tarea3 = Task.Factory.StartNew((o) => 
            {
                Thread.Sleep(5000);
                Console.WriteLine("Tarea 3 dice 'Hola me llamo {0}'", o);
            },
            "Carlos");

            Task tarea4 = Task.Run(() =>
            {
                Console.WriteLine("Contamos del 1000 al 2000 de 10 en 10");

                for (int i = 1000; i < 2000; i += 10)
                {
                    Console.WriteLine("Tarea 4 dice {0}", i);
                }
            });
        }
        void MetodoNormal()
        {
            Task tarea = Task.Run(() =>
            {
                Console.WriteLine("Contamos de 5000 a 10000 de 5 en 5");
                for (int i = 5000; i < 10000; i+=5)
                {
                    Console.WriteLine("Tarea de método normal dice {0}",i);
                }
            });
        }
    }
}
