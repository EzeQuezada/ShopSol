
using System.Linq.Expressions;

namespace ShopSol.Common.Data.Repository
{
    /// <summary>
    /// interfaces base para los repositorios de datos
    /// </summary>
    /// <typeparam name="TEntity">Entidad con la que se va a trabajar </typeparam>
    /// <typeparam name="TType">id por donde se va buscar </typeparam>
    public interface IBaseRepository <TEntity,TType> where TEntity : class
    {
        void save (TEntity entity);
        void Update (TEntity entity);
        void Remove(TEntity entity);
        List<TEntity> GetAll ();
        TEntity GetEntityBy (TType id);
        bool Exists(Expression<Func<TEntity, bool>> filter);    
    }
}
