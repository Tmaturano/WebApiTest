using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfTest.Classes;

namespace WcfTest.Services
{
    [ServiceContract]
    public interface IRestauranteService
    {
        [OperationContract]
        IEnumerable<Restaurante> BuscarTodosRestaurantes();

        [OperationContract]
        Restaurante BuscarRestaurantePorId(int id);

        [OperationContract]
        bool AdicionarRestaurante(Restaurante restaurante);

    }
}
