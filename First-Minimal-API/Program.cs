using First_Minimal_API.Endpoints;
using First_Minimal_API.Models;

namespace First_Minimal_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            var inMemDb = new List<Person>
            {
                new Person(1, "Åmund"),
                new Person(2, "Herman"),
                new Person(3, "Emil"),
                new Person(4, "Alex"),
                new Person(5, "Sondre")
            };

            var personEndpoints = new PersonEndpoints(inMemDb);

            app.MapGet("/person", personEndpoints.SelectAllPersons);

            app.MapGet("/person/id/{id}", personEndpoints.SelectPersonById);

            app.MapPost("/person", personEndpoints.InsertPerson);

            app.MapPut("/person", personEndpoints.UpdatePerson);

            app.MapDelete("/person/id/{id}", personEndpoints.DeletePerson);

            app.Run();
        }
    }
}