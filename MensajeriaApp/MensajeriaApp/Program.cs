using MensajeriaModel.DAL;
using MensajeriaModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeriaApp
{
    class Program
    {
        static IMensajesDAL dal = MensajesDALFactory.CreateDAL();

        static void IngresarMensaje()
        {
            string nombre, detalle;
            do
            {
                Console.WriteLine("Ingrese el Nombre:");
                nombre = Console.ReadLine().Trim();
            } while (nombre == string.Empty);
            do
            {
                Console.WriteLine("Ingrese el detalle:");
                detalle = Console.ReadLine().Trim();
            } while (detalle == string.Empty);
            Mensaje m = new Mensaje();
            m.Nombre = nombre;
            m.Detalle = detalle;
            m.Tipo = "Aplicacion";
            dal.Save(m);
        }
        static void MostrarMensaje()
        {
            List<Mensaje> mensajes = dal.GetAll();
            mensajes.ForEach(m =>
            {
                Console.WriteLine("Nombre: {0} | Detalle:{1} | Tipo: {2}", m.Nombre, m.Detalle, m.Tipo);
            });
        }
        static bool menu()
        {
            bool continuar = true;
            Console.WriteLine("Seleccione Opcion:");
            Console.WriteLine("1. Ingresar Mensaje");
            Console.WriteLine("2. Mostrar Mensaje");
            string opcion = Console.ReadLine().Trim();
            switch (opcion)
            {
                case "1": IngresarMensaje();
                    break;
                case "2": MostrarMensaje();
                    break;
                case "0": continuar = false;
                    break;
            }
            return continuar;
        }

        static void Main(string[] args)
        {
            while (menu());
        }
    }
}
