using System.Collections.Generic;

namespace OpportunitoolApi.Persistence.Repositories
{
    /// <summary>
    /// Interface providing generic contracts for a repository.
    /// </summary>
    /// <remarks>
    /// This interface should not be implemented directly by a repository.
    /// </remarks>
    /// <typeparam name="T">The type of the entity to be stored in the repository. Should have an id field.</typeparam>
    /// <typeparam name="ID">The type of the id of the entity to be stored in the repository.</typeparam>
    public interface IGenericRepo<T, ID>
    {
        // TODO: Implement a way to filter results.

        /// <summary>
        /// Retrieves a single entity from the database that has the given <paramref name="id"/>.
        /// </summary>
        /// <remarks>
        /// If no entity with the given id was found then a <code>Default</code> object is returned.
        /// </remarks>
        /// <param name="id">The id of the entity to be retrieved.</param>
        /// <returns>The found entity or a <see>Default</see> object if none is found.</returns>
        T GetById(ID id);

        /// <summary>
        /// Retrieves all entities from the database.
        /// </summary>
        /// <remarks>
        /// TODO: In the future implement a way to paginate the results.
        /// </remarks>
        /// <returns>All of the entities stored in the database.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Adds an <paramref name="entity"/> to the database.
        /// </summary>
        /// <param name="entity">The entity to be added to the database.</param>
        /// <returns>True if the adding of the entity succeeded, false otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the given <paramref name="entity"/> is null.</exception>
        bool Add(T entity);

        /// <summary>
        /// Updates an <paramref name="entity"/> from the database.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>True if the updating of the entity succeeded, false otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the given <paramref name="entity"/> is null.</exception>
        bool Update(T entity);

        /// <summary>
        /// Removes an <paramref name="entity"/> from the database.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        /// <returns>True if the removing of the entity succeeded, false otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the given <paramref name="entity"/> is null.</exception>
        bool Delete(T entity);
    }
}