using System.Linq.Expressions;

namespace SQLQueryBuilder.QueryBuilderStatements;

public interface IAndStatement : IQuery
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
  /// Ors the specified condition.
  /// </summary>
  /// <param name="condition">The condition.</param>
  /// <returns></returns>
  IOrStatement Or ( string condition );
  /// <summary>
  /// Ands the statement.
  /// </summary>
  /// <param name="condition">The condition.</param>
  /// <returns></returns>
  IAndStatement AndStatement ( string condition );
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
  /// <param name="group">The group.</param>
  /// <returns></returns>
  IGroupStatement GroupBy<T> ( params Expression<Func<T, object>>[] group ) where T : class;
  /// <summary>
  /// Limits the specified limit.
  /// </summary>
  /// <param name="limit">The limit.</param>
  /// <returns></returns>
  ILimitStatement Limit ( int limit );
}
