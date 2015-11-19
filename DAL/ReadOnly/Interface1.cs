using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IReadOlnyRepository<T> where T : class, new()
    {
        /// <summary>
        /// Get records from database as a collection
        /// </summary>
        /// <param name="limit">specify the size of the returned collection </param>
        /// <param name="offset">specify the start point of cursor in a table that will be selected.</param>
        /// <returns>a collection of records that selected from database </returns>
        IEnumerable<T> get(int limit = 10, int offset = 0);
        T getById(int id);
    }
}