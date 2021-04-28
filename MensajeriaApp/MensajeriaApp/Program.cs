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

        static void Main(string[] args)
        {
            Mensaje m = new Mensaje()
            {
                Nombre = "Lucho",
                Detalle = "Detallado",
                Tipo = "Tipazo"
            };
            dal.Save(m);
        }
    }
}
