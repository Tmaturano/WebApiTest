using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfTeste.Classes;

namespace WcfTeste.RestauranteService
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
