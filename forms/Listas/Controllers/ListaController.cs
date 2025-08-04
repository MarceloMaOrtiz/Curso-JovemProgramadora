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
    public class ListaController : BaseController<Lista>
    {
        public ListaController(ListasDbContext context) : base(context)
        {
        }
        // Aqui você pode adicionar métodos específicos para o controlador de Lista, se necessário.
        // Por exemplo, você pode querer adicionar métodos para filtrar ou buscar listas por categoria.
    }
}
