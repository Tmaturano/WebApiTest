using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfTest.Classes;

namespace WcfTest.Services
{
    public class RestauranteService : IRestauranteService
    {
        private List<Restaurante> _restaurantes = null;

        public RestauranteService()
        {
            if (_restaurantes == null)
            {
                _restaurantes = new List<Restaurante>();
                _restaurantes.Add(new Restaurante() { Id = 1, Nome = "Restaurante Linx Joinville", Endereco = "Rua Tenente Antônio João" });
                _restaurantes.Add(new Restaurante() { Id = 2, Nome = "Restaurante Linx São Paulo", Endereco = "Rua Morumbi" });
                _restaurantes.Add(new Restaurante() { Id = 3, Nome = "Restaurante Linx Rio de Janeiro", Endereco = "Rua Copacabana" });
            }
        }

        public IEnumerable<Restaurante> BuscarTodosRestaurantes()
        {
            return _restaurantes.ToList();
        }

        public Restaurante BuscarRestaurantePorId(int id)
        {
            return _restaurantes.FirstOrDefault(r => r.Id == id);            
        }

        public bool AdicionarRestaurante(Restaurante restaurante)
        {
            if (!CheckIfRestaurantExists(restaurante.Id))
                _restaurantes.Add(restaurante);
            else
                return false;

            return true;
        }

        private bool CheckIfRestaurantExists(int id)
        {
            return (_restaurantes.Where(p => p.Id.Equals(id)).Any());
        }
    }
}
