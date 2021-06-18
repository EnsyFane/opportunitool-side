using System.Collections.Generic;

namespace OpportunitoolApi.Persistence.Repositories
{
    /// <summary>
    /// Interface providing generic contracts for a repository.
    /// </summary>
    /// <typeparam name="T">The type of the entity to be stored in the repository. Should have an id field.</typeparam>
    /// <typeparam name="ID">The type of the id of the entity to be stored in the repository.</typeparam>
    public interface IGenericRepo<T, ID>
    {
        T GetById(ID id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}