using SQLQueryBuilder.QueryBuilderStatements;
using System.Linq.Expressions;
using System.Text;

namespace SQLQueryBuilder
{
  public class QueryBuilder : ISelectStatement,
    IWhereStatement,
    IOrderStatement,
    IGroupStatement,
    ILimitStatement,
    IHavingStatement,
    IAndStatement,
    IOrStatement
  {
    private readonly string _table;
    private StringBuilder QuerySpan { get; set; }
    public QueryBuilder ( string table )
    {
      _table = table;
      QuerySpan = new StringBuilder ();
    }

    internal ISelectStatement Select ( params string[] columns )
    {
      var selectStatement = columns.Any () ? string.Join (",", columns) : "*";
      QuerySpan.Append ($"SELECT {selectStatement} FROM {_table}");
      return this;
    }

    public IAndStatement And ( string condition )
    {
      QuerySpan.Append ($" AND {condition}");
      return this;
    }

    public IAndStatement AndStatement ( string condition )
    {
      QuerySpan.Append ($" AND {condition}");
      return this;
    }

    public string ConstructQuery ()
    {
      return QuerySpan.ToString ();
    }

    public IGroupStatement GroupBy ( string group )
    {
      throw new NotImplementedException ();
    }

    public IHavingStatement Having ( string having )
    {
      QuerySpan.Append ($" HAVING {having}");
      return this;
    }

    public ILimitStatement Limit ( int limit )
    {
      QuerySpan.Append ($" LIMIT {limit}");
      return this;
    }

    public IOrStatement Or ( string condition )
    {
      QuerySpan.Append ($" OR {condition}");
      return this;
    }

    public IOrderStatement OrderBy ( string order )
    {
      QuerySpan.Append ($" ORDER BY {order}");
      return this;
    }

    public IOrStatement OrStatement ( string condition )
    {
      QuerySpan.Append ($" OR {condition}");
      return this;
    }

    public IWhereStatement Where ( string condition )
    {
      QuerySpan.Append ($" WHERE {condition}");
      return this;
    }

    public IOrderStatement OrderBy<T> ( Expression<Func<T, object>> order, SortDirection direction ) where T : class
    {
      var paramName = order.GetParamName ();
      var sortDirection = direction == SortDirection.Ascending ? "" : "desc";
      QuerySpan.Append ($" ORDER BY {paramName} {sortDirection}");
      return this;

    }
    public IGroupStatement GroupBy<T> ( params Expression<Func<T, object>>[] group ) where T : class
    {
      var paramNames = string.Join (',', group.Select (x => x.GetParamName ()));
      QuerySpan.Append ($" GROUP BY {paramNames}");
      return this;

    }
    public IOrderStatement ThenBy ( string order )
    {
      QuerySpan.Append ($", {order}");
      return this;
    }
    public IOrderStatement ThenBy<T> ( Expression<Func<T, object>> order, SortDirection sortDirection ) where T : class
    {
      var paramName = order.GetParamName ();
      var direction = sortDirection == SortDirection.Ascending ? "" : "desc";
      QuerySpan.Append ($", {paramName} {direction}");
      return this;
    }
  }
}