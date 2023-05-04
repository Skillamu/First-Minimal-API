using First_Minimal_API.Models;

namespace First_Minimal_API.Endpoints
{
    public class PersonEndpoints
    {
        private List<Person> _inMemDb;

        public PersonEndpoints(List<Person> inMemDb)
        {
            _inMemDb = inMemDb;
        }

        public Person? FindPersonById(int id)
            => _inMemDb.FirstOrDefault(person => person.Id == id);

        public List<Person> ListAllPersons()
            => _inMemDb;

        public void AddNewPerson(Person person)
            => _inMemDb.Add(person);
    }
}
