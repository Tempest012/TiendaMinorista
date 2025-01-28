using System;
using MongoDB.Bson;
using MongoDB.Driver;


namespace TiendaMinorista
{
    class Program
    {
        private static IMongoCollection<BsonDocument> _collection;

        static void Main(string[] args)
        {
            // Configuración de la conexión con MongoDB
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TiendaMinoristaDB"); // Nombre de la base de datos
            _collection = database.GetCollection<BsonDocument>("ProductoCollection"); // Nombre de la colección

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nCRUD Tienda Minorista:");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Consultar Producto");
                Console.WriteLine("3. Consultar Producto por ID");
                Console.WriteLine("3. Actualizar Producto");
                Console.WriteLine("4. Eliminar Producto");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                        case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}