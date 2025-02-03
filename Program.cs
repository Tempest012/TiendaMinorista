using System;
using MongoDB.Bson;
using MongoDB.Driver;


namespace TiendaMinorista
{
    class Program
    {
        private static IMongoCollection<BsonDocument> _collection;

        public static void Main(string[] args)
        {
            // Configuración de la conexión con MongoDB
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("TiendaMinoristaDB"); // Nombre de la base de datos
            _collection = database.GetCollection<BsonDocument>("ProductoCollection"); // Nombre de la colección

            Oxxo oxxo = new Oxxo(_collection);
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nCRUD Tienda Minorista:");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Consultar todo los productos");
                Console.WriteLine("3. Consultar Productos por nombre");
                Console.WriteLine("4. Consultar Productos por categoría");
                Console.WriteLine("5. Consultar Productos por precio");
                Console.WriteLine("6. Actualizar Producto");
                Console.WriteLine("7. Eliminar Producto");
                Console.WriteLine("8. Salir");
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        oxxo.AgregarProductos();
                        break;
                    case "2":
                        Console.Clear();
                        oxxo.ConsultarProductos();
                        break;
                    case "3":
                        Console.Clear();
                        oxxo.ConsultarProductosPorNombre();
                        break;
                    case "4":
                        Console.Clear();
                        oxxo.ConsultarProductosPorCategoria();
                        break;
                    case "5":
                        Console.Clear();
                        oxxo.ConsultarProductosPorPrecio();
                        break;
                    case "6":
                        Console.Clear();
                        oxxo.ActualizarProducto();
                        break;
                    case "7":
                        Console.Clear();
                        oxxo.EliminarProducto();
                        break;
                    case "8":
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