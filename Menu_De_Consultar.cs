using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMinorista
{
    class Menu_De_Consultar
    {
        private static IMongoCollection<BsonDocument> _collection;

        public static void ConsultarProductos(string[] args)
        {
            Oxxo oxxo = new Oxxo(_collection);
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nCRUD Tienda Minorista:");
                Console.WriteLine("1. Consultar todos Producto");
                Console.WriteLine("2. Consultar Producto por nombre");
                Console.WriteLine("3. Consultar Producto por categoría");
                Console.WriteLine("4. Consultar Producto por precios");
                Console.WriteLine("5. Regresar");
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        oxxo.ConsultarProductos();
                        break;
                    case "2":
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        break;
                    case "5":
                        TiendaMinorista.Program.Main(new string[0]);
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}
