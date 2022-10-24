using System.Linq.Expressions;

namespace SQLQueryBuilder.QueryBuilderStatements;

public interface IHavingStatement : IQuery
{
  /// <summary>
  /// Orders the by.
  /// </summary>
  /// <param name="order">The order.</param>
  /// <returns></returns>
  IOrderStatement OrderBy ( string order );
  /// <summary>
  /// Orders the by.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="order">The order.</param>
  /// <param name="sortDirection">The sort direction.</param>
  /// <returns></returns>
  IOrderStatement OrderBy<T> ( Expression<Func<T, object>> order,
    SortDirection sortDirection = SortDirection.Ascending ) where T : class;
  /// <summary>
  /// Limits the specified limit.
  /// </summary>
  /// <param name="limit">The limit.</param>
  /// <returns></returns>
  ILimitStatement Limit ( int limit );
}
