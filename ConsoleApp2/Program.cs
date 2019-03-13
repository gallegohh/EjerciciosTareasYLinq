using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Modelos;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Consultas.Query10();

            Console.ReadKey();
        }
    }

    //TODO Resuelve las consultas mediante LINQ
    public static class Consultas
    {

        //TODO Retorna una lista de productos agrupados por Categoría mediante LINQ
        public static void Query1()
        {
            Northwind db = new Northwind();
            var q1 = db.Products
                .GroupBy(p => p.Categories.CategoryName)
                .Select(k => new
                {
                    id = k.Key,
                    cuenta = k.Sum(s => s.ProductID)
                })
                .ToList();

            var q2 = db.Products
                .Select(p => new
                {
                    nombre = p.ProductName,
                    categoria = p.Categories.CategoryName
                })
                    .ToList();

            foreach (var item in q2)
            {
                Console.WriteLine("Nombre del producto: {0} - Nombre de las categorias: {1}",
                    item.nombre, item.categoria);
            }

            //foreach (var item in q1)
            //{
            //    Console.WriteLine("{0} - {1}",item.id,item.cuenta);
            //}
           
        }

        //TODO Retorna una lista de productos agrupados por la primera letra del nombre de producto mediante LINQ
        public static void Query2()
        {
            Northwind db = new Northwind();
            var q2 = db.Products
                .OrderBy(s => s.ProductName)
                .ToList();

            var q3 = db.Products
                .GroupBy(p => p.ProductName.Substring(0,1))
                .Select(s => new
                {
                    inicial = s.Key,
                    cantidad = s.Count()
                })
                .ToList();

            foreach (var item in q3)
            {
                Console.WriteLine("{0}# - {1}",
                    item.inicial,item.cantidad);
            }

            foreach (var item in q2)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        //TODO Retorna el array ordenado mediante LINQ
        public static void Query3()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var q1 = words.OrderBy(s => s);
            foreach (var item in q1)
            {
                Console.WriteLine(item);
            }
        }

        //TODO Retorna el array transformado en un diccionarios mediante LINQ
        public static void Query4()
        {
            var scoreRecords = new[] {
                new {Name = "Alice", Score = 50},
                new {Name = "Bob"  , Score = 40},
                new {Name = "Cathy", Score = 45}
            };

            var q1 = scoreRecords.ToDictionary(s => s.Name, s => s.Score);
            foreach (var item in q1)
            {
                Console.WriteLine("Key[{0}] - Valor -> {1}",item.Key,item.Value);
            }
        }

        //TODO Retorna una lista solo con los elementos convertibles a Double mediante LINQ
        //     Utiliza OfType<T>()
        public static void Query5()
        {
            object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };

            var q1 = numbers.OfType<double>();

            foreach (var item in q1)
            {
                Console.WriteLine(item);
            }
        }


        //TODO Retorna una lista de categorias sin duplicados utilizando la tabla de productos mediante LINQ
        public static void Query6()
        {
            Northwind db = new Northwind();
            var q1 = db.Products
                .Select(p => p.Categories.CategoryName)
                .Distinct()
                .ToList();

            foreach (var item in q1)
            {
                Console.WriteLine(item);
            }
        }

        //TODO Retorna el lista con los elementos de los dos arrays mediante LINQ
        //     Utiliza el método Union de LINQ
        public static void Query7()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var q1 = numbersA.Union(numbersB);
            foreach (var item in q1)
            {
                Console.WriteLine(item);
            }
        }

        //TODO Retorna el lista con los elementos repetidos en los dos arrays mediante LINQ
        //     Utiliza el método Intersect de LINQ
        public static void Query8()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var q1 = numbersA.Intersect(numbersB);

            foreach (var item in q1)
            {
                Console.WriteLine(item);
            }

        }

        //TODO Retorna el lista con los elementos más la posición mediante LINQ (la primera posición es 1)
        public static void Query9()
        {
            int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var q1 = numbers;
             
        }

        //TODO Retorna una lista de clientes con la compañia de transporte que gestiona la entrega de sus pedidos mediante LINQ
        //     Utiliza un JOIN de LINQ donde suppliers.Country es igual customers.Country
        //     Muestra los siguientes campos suppliers.Country, suppliers.SupplierName, customers.CompanyName
        //     Tablas: Customers y Suppliers
        public static void Query10()
        {
            Northwind db = new Northwind();
            var q1 = db.Customers
                .Join(db.Suppliers, c => c.Country, s => s.Country, (c, s) => new
                {
                    s.Country,
                    s.ContactName,
                    c.CompanyName
                })
                .Distinct()
                .ToList();

            foreach (var item in q1)
            {
                Console.WriteLine("{0} {1} {2}",item.Country,item.ContactName,item.CompanyName);
            }
        }
    }
}

