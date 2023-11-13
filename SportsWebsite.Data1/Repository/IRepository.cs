namespace SprotsWebsite.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// GetByIdAsync all elements from a table.
        /// </summary>
        /// <returns>IQueryable list of elements.</returns>
        IQueryable<TEntity> GetAsIQueryable();

        /// <summary>
        /// GetByIdAsync all elements from a table without tracking changes.
        /// </summary>
        /// <returns>IQueryable list of elements.</returns>
        IQueryable<TEntity> GetWithNoTracking();

        /// <summary>
        /// GetByIdAsync element by id.
        /// </summary>
        /// <param name="id">The id of the element.</param>
        /// <returns>The element with the same id.</returns>
        Task<TEntity> GetByIdAsync(object id);

        /// <summary>
        /// Insert element to the table.
        /// </summary>
        /// <param name="element">The element to add to the table.</param>
        TEntity Insert(TEntity element);

        /// <summary>
        /// Insert element to the table.
        /// </summary>
        /// <param name="element">The element to add to the table.</param>
        Task<TEntity> InsertAsync(TEntity element);

        /// <summary>
        /// Insert multiple elements to the table.
        /// </summary>
        /// <param name="elements">The elements to add to the table.</param>
        void InsertRange(IEnumerable<TEntity> elements);

		/// <summary>
		/// Insert multiple elements to the table.
		/// </summary>
		/// <param name="elements">The elements to add to the table.</param>
		Task InsertRangeAsync(IEnumerable<TEntity> elements);

        /// <summary>
        /// Update element attributes.
        /// </summary>
        /// <param name="element">The element to update.</param>
        TEntity Update(TEntity element);

        /// <summary>
        /// Update element attributes.
        /// </summary>
        /// <param name="element">The element to update.</param>
        void UpdateRange(IEnumerable<TEntity> element);

        /// <summary>
        /// Soft deletes element in table.
        /// </summary>
        /// <param name="element">The element to delete.</param>
        /// <returns>Boolean True or false</returns>
        bool Delete(TEntity element);

        /// <summary>
        /// Hard deletes element from table.
        /// </summary>
        /// <param name="element">The element to delete.</param>
        /// <returns>Boolean True or false</returns>
        bool HardDelete(TEntity element);
    }
}
