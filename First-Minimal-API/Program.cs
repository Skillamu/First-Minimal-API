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

            app.MapGet("/person", personEndpoints.ListAllPersons);

            app.MapGet("/person/id/{id}", personEndpoints.FindPersonById);

            app.MapPost("/person", personEndpoints.AddNewPerson);

            app.Run();
        }
    }
}