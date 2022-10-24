using SQLQueryBuilder;
using SQLQueryBuilder.QueryBuilderStatements;

Console.WriteLine ("Hello, World!");
var person = new Person ();
var query = QueryExtensions
  .SqlSelectFor<Person> ("dbo.Person", x => x.Age, x => x.Name, x => x.Id)
  .Where ("Id = @Id")
  .And ("Name like %@Name%")
  .OrderBy<Person>(x=>x.Age).ThenBy<Person>(x=>x.Id,SortDirection.Descending)
  .Limit (10)
  .ConstructQuery ();
Console.WriteLine (query);