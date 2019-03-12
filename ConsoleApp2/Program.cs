﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Consultas.Query1();

            Console.ReadKey();
        }
    }

    //TODO Resuelve las consultas mediante LINQ
    public static class Consultas
    {

        //TODO Retorna una lista de productos agrupados por Categoría mediante LINQ
        public static void Query1()
        {
           
        }

        //TODO Retorna una lista de productos agrupados por la primera letra del nombre de producto mediante LINQ
        public static void Query2()
        {
        }

        //TODO Retorna el array ordenado mediante LINQ
        public static void Query3()
        {
            string[] words = { "cherry", "apple", "blueberry" };
        }

        //TODO Retorna el array transformado en un diccionarios mediante LINQ
        public static void Query4()
        {
            var scoreRecords = new[] {
                new {Name = "Alice", Score = 50},
                new {Name = "Bob"  , Score = 40},
                new {Name = "Cathy", Score = 45}
            };
        }

        //TODO Retorna una lista solo con los elementos convertibles a Double mediante LINQ
        //     Utiliza OfType<T>()
        public static void Query5()
        {
            object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0 };
        }


        //TODO Retorna una lista de categorias sin duplicados utilizando la tabla de productos mediante LINQ
        public static void Query6()
        {
        }

        //TODO Retorna el lista con los elementos de los dos arrays mediante LINQ
        //     Utiliza el método Union de LINQ
        public static void Query7()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
        }

        //TODO Retorna el lista con los elementos repetidos en los dos arrays mediante LINQ
        //     Utiliza el método Intersect de LINQ
        public static void Query8()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
        }

        //TODO Retorna el lista con los elementos más la posición mediante LINQ (la primera posición es 1)
        public static void Query9()
        {
            int[] numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        }

        //TODO Retorna una lista de clientes con la compañia de transporte que gestiona la entrega de sus pedidos mediante LINQ
        //     Utiliza un JOIN de LINQ donde suppliers.Country es igual customers.Country
        //     Muestra los siguientes campos suppliers.Country, suppliers.SupplierName, customers.CompanyName
        //     Tablas: Customers y Suppliers
        public static void Query10()
        {
        }
    }
}
