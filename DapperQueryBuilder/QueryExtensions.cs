using SQLQueryBuilder.QueryBuilderStatements;
using System.Linq.Expressions;

namespace SQLQueryBuilder;

public static class QueryExtensions
{

  public static ISelectStatement SqlSelect<T> ( this T entity, params string[] columns ) where T : class
  {
    return new QueryBuilder ($"dbo.{entity.GetType ().Name}").Select (columns);
  }
  public static ISelectStatement SqlSelect ( string table, params string[] columns )
  {
    return new QueryBuilder (table).Select (columns);
  }
  public static ISelectStatement SqlSelectFor<T> ( this T entity,
    params Expression<Func<T, object>>[] columnExpressions ) where T : class
  {
    var columns = columnExpressions.Select (x => x.GetParamName ());
    return new QueryBuilder ($"dbo.{entity.GetType ().Name}").Select (columns.ToArray ());
  }

  public static ISelectStatement SqlSelectFor<T> ( string table,
    params Expression<Func<T, object>>[] columnExpressions ) where T : class
  {
    var columns = columnExpressions.Select (x => x.GetParamName ());
    return new QueryBuilder (table).Select (columns.ToArray ());
  }
}

internal static class ExtensionsHelper
{
  public static string GetParamName<T> ( this Expression<Func<T, object>> expression ) where T : class
  {

    switch ( expression.Body )
    {
      case MemberExpression member:
        return member.Member.Name;
      case UnaryExpression unary when unary.Operand is MemberExpression unMem:
        return unMem.Member.Name;
      default:
        return expression.Compile ()!.ToString ();
    }

  }
}