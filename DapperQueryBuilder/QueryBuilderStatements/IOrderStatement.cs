using System.Linq.Expressions;

namespace SQLQueryBuilder.QueryBuilderStatements;

public interface IOrderStatement : IQuery
{
  /// <summary>
  /// Groups the by.
  /// </summary>
  /// <param name="group">The group.</param>
  /// <returns></returns>
  IGroupStatement GroupBy ( string group );
  /// <summary>
  /// Groups the by.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="groupBys">The group bys.</param>
  /// <returns></returns>
  IGroupStatement GroupBy<T> ( params Expression<Func<T, object>>[] groupBys ) where T : class;
  /// <summary>
  /// Thens the by.
  /// </summary>
  /// <param name="order">The order.</param>
  /// <returns></returns>
  IOrderStatement ThenBy ( string order );
  /// <summary>
  /// Thens the by.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="order">The order.</param>
  /// <param name="sortDirection">The sort direction.</param>
  /// <returns></returns>
  IOrderStatement ThenBy<T> ( Expression<Func<T, object>> order,
    SortDirection sortDirection = SortDirection.Ascending ) where T : class;
  /// <summary>
  /// Limits the specified limit.
  /// </summary>
  /// <param name="limit">The limit.</param>
  /// <returns></returns>
  ILimitStatement Limit ( int limit );
}
