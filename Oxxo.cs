using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMinorista
{
    class Oxxo
    {
        private static IMongoCollection<BsonDocument> _collection;

        public Oxxo(IMongoCollection<BsonDocument> collection)
        {
            _collection = collection;
        }
        public void AgregarProductos()
        {

            Console.WriteLine("Ingresa el nombre del producto");
            var nombre = Console.ReadLine();

            Console.WriteLine("Ingresa la categoría del producto");
            var category = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del producto");
            if(!double.TryParse(Console.ReadLine(), out var precio))
            {
                Console.WriteLine("El precio ingresado no es válido");
                return;
            }

            var documento = new BsonDocument
            {
                { "nombre",nombre },
                { "category",category },
                { "precio", precio }
            };
            _collection.InsertOne(documento);
            Console.WriteLine("Producto agregado exitosamente");
         }
        
        public void ConsultarProductos()
        {
            if (_collection == null)
            {
                Console.WriteLine("La colección no ha sido inicializada");
                return;
            }
            else
            {
                var productos = _collection.Find(new BsonDocument()).ToList();
                if(productos.Count == 0)
                {
                    Console.WriteLine("No hay productos");
                    return;
                }
                Console.WriteLine("\nProductos en la colección:");
                foreach (var producto in productos)
                {
                    Console.WriteLine(producto.ToJson());
                }
            }
        }
        public void ConsultarProductosPorNombre()
        {
            Console.WriteLine("Ingresa el nombre del producto a buscar");
            var nombre = Console.ReadLine();
            var filter = Builders<BsonDocument>.Filter.Eq("nombre", nombre);
            var productos = _collection.Find(filter).ToList();
            if (productos.Count == 0)
            {
                Console.WriteLine("No se encontraron productos con ese nombre");
                return;
            }
            Console.WriteLine("\nProductos encontrados:");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto.ToJson());
            }
        }
        public void ConsultarProductosPorCategoria()
        {
            Console.WriteLine("Ingresa la categoría del producto a buscar");
            var category = Console.ReadLine();
            var filter = Builders<BsonDocument>.Filter.Eq("category", category);
            var productos = _collection.Find(filter).ToList();
            if (productos.Count == 0)
            {
                Console.WriteLine("No se encontraron productos con esa categoría");
                return;
            }
            Console.WriteLine("\nProductos encontrados:");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto.ToJson());
            }
        }
        public void ConsultarProductosPorPrecio()
        {
            Console.WriteLine("Ingresa el precio del producto a buscar");
            if (!double.TryParse(Console.ReadLine(), out var precio))
            {
                Console.WriteLine("El precio ingresado no es válido");
                return;
            }
            var filter = Builders<BsonDocument>.Filter.Eq("precio", precio);
            var productos = _collection.Find(filter).ToList();
            if (productos.Count == 0)
            {
                Console.WriteLine("No se encontraron productos con ese precio");
                return;
            }
            Console.WriteLine("\nProductos encontrados:");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto.ToJson());
            }
        }
        public void ActualizarProducto()
        {
            Console.WriteLine("Ingresa el nombre del producto a actualizar");
            var nombre = Console.ReadLine();
            var filter = Builders<BsonDocument>.Filter.Eq("nombre", nombre);
            var producto = _collection.Find(filter).FirstOrDefault();
            if (producto == null)
            {
                Console.WriteLine("No se encontró el producto");
                return;
            }
            Console.WriteLine("Ingresa el nuevo nombre del producto");
            var nuevoNombre = Console.ReadLine();
            Console.WriteLine("Ingresa la nueva categoría del producto");
            var nuevaCategoria = Console.ReadLine();
            Console.WriteLine("Ingresa el nuevo precio del producto");
            if (!double.TryParse(Console.ReadLine(), out var nuevoPrecio))
            {
                Console.WriteLine("El precio ingresado no es válido");
                return;
            }
            var update = Builders<BsonDocument>.Update
                .Set("nombre", nuevoNombre)
                .Set("category", nuevaCategoria)
                .Set("precio", nuevoPrecio);
            _collection.UpdateOne(filter, update);
            Console.WriteLine("Producto actualizado exitosamente");
        }
        public void EliminarProducto()
        {
            Console.WriteLine("Ingresa el nombre del producto a eliminar");
            var nombre = Console.ReadLine();
            var filter = Builders<BsonDocument>.Filter.Eq("nombre", nombre);
            var producto = _collection.Find(filter).FirstOrDefault();
            if (producto == null)
            {
                Console.WriteLine("No se encontró el producto");
                return;
            }
            _collection.DeleteOne(filter);
            Console.WriteLine("Producto eliminado exitosamente");
        }
    }
}
