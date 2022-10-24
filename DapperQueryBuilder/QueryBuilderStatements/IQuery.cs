namespace SQLQueryBuilder.QueryBuilderStatements;


public interface IQuery
{
  /// <summary>
  /// Constructs the query.
  /// </summary>
  /// <returns></returns>
  string ConstructQuery ();
}