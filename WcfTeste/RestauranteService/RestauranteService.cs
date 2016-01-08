using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfTeste.Classes;

namespace WcfTeste.RestauranteService
{
    public class RestauranteService : IRestauranteService
    {
        public IEnumerable<Restaurante> BuscarTodosRestaurantes()
        {
            throw new NotImplementedException();
        }

        public Restaurante BuscarRestaurantePorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool AdicionarRestaurante(Restaurante restaurante)
        {
            throw new NotImplementedException();
        }
    }
}