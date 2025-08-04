using Controllers.Base;
using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ExercicioController : BaseController<Exercicio>
    {
        public ExercicioController(ListasDbContext context) : base(context)
        {
        }
        // Aqui você pode adicionar métodos específicos para o controlador de Exercicio, se necessário.
        // Por exemplo, você pode querer adicionar métodos para filtrar ou buscar exercícios por categoria.
    }
}
