using KoiManagement_Business;
using KoiManagement_Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KoiManagement_Repository.Repository
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		protected Prn221Context _context;
		public RepositoryBase(Prn221Context context)
		{
			_context = context;
		}
		public void Create(T entity) => _context.Set<T>().Add(entity);

		public void Delete(T entity) => _context.Set<T>().Remove(entity);

		public IQueryable<T> FindAll(bool trackChanges) =>
			!trackChanges ?
			_context.Set<T>().AsNoTracking() :
			_context.Set<T>();

		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
			!trackChanges ?
		  _context.Set<T>()
			.Where(expression)
			.AsNoTracking() :
		  _context.Set<T>()
			.Where(expression);

		public void Update(T entity) => _context.Set<T>().Update(entity);
	}
}
