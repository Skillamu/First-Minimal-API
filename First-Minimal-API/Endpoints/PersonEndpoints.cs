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

        public Person? SelectPersonById(int id)
            => _inMemDb.FirstOrDefault(person => person.Id == id);

        public List<Person> SelectAllPersons()
            => _inMemDb;

        public void InsertPerson(Person person)
            => _inMemDb.Add(person);

        public void UpdatePerson(Person person)
        {
            var personFromDb = _inMemDb.FirstOrDefault(
                               p => p.Id == person.Id);

            if (personFromDb is null) return;

            personFromDb.Name = person.Name;
        }

        public void DeletePerson(int id)
        {
            var personFromDb = _inMemDb.FirstOrDefault(
                               p => p.Id == id);

            if (personFromDb is null) return;

            _inMemDb.Remove(personFromDb);
        }
    }
}
