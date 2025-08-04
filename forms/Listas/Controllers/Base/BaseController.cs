using Data;

namespace Controllers.Base
{
    public class BaseController<T> where T : class
    {
        protected readonly ListasDbContext _context;

        public BaseController(ListasDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual IEnumerable<T> ListarTodos()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T? ObterPorId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual void Adicionar(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Atualizar(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public virtual void Excluir(int id)
        {
            var entity = ObterPorId(id);
            if (entity == null) throw new KeyNotFoundException($"Entity with ID {id} not found.");
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
