using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Demo demo = new Demo();
            demo.Comenzar();
            Console.ReadKey();
        }
    }

    public class Demo
    {
        //TODO Realiza una llamada al método asíncrono para buscar un producto
        //TODO Realiza una llamada al método síncrono para buscar un producto
        public void Comenzar()
        {
            Console.WriteLine("Comienza el método Comenzar()");
            BuscarProductoAsync("Queso");

            var q2 = BuscarProducto("Tofu");
            foreach (var item in q2)
            {
                Console.WriteLine(item.ProductName);
            }
            Console.WriteLine("Termina el método Comenzar()");
        }

        //TODO Crear un método asíncrono BuscarProductoAsync que retorna una lista de Productos
        //TODO El método tiene un parámetro de tipo string con el nombre del producto a buscar

        //TODO Opcionalmente añade el espacio de nombres System.Data.Entity y finaliza la sentencia
        //     de LINQ con AsQueryable().ToListAsync()

        //LA FIRMA DEL MÉTODO NO ES CORRECTA, SOLAMENTE ORIENTATIVA
        public async Task<List<Products>> BuscarProductoAsync(string nombreProducto)
        {
            Console.WriteLine("Comienza el método asíncrono");
            List<Products> listaProductos = new List<Products>();
            ModelNorthwind db = new ModelNorthwind();

            listaProductos = await db.Products
                .Where(p => p.ProductName.Contains(nombreProducto))
                .AsQueryable().ToListAsync();

            foreach (var item in listaProductos)
            {
                Console.WriteLine(item.ProductName);
            }
            Console.WriteLine("Termina el método asíncrono");
            return listaProductos;
        }


        //TODO Crear un métdo sincrono que implemente la misma lógica del método asíncrono
        //TODO Reutiliza el código del método asíncrono realizando una llamada al mismo para resolver
        //     la búsqueda del producto.

        //LA FIRMA DEL MÉTODO NO ES CORRECTA, SOLAMENTE ORIENTATIVA
        public List<Products> BuscarProducto(string nombreProducto)
        {
            Console.WriteLine("Comienza el método síncrono");
            
            return BuscarProductoAsync(nombreProducto).Result;
        }

    }
}
