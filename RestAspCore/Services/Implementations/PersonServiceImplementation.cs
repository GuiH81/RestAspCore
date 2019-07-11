using System;
using System.Collections.Generic;
using System.Threading;
using RestAspCore.Model;

namespace RestAspCore.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
            //throw new NotImplementedException();
        }

        public void Delete(long id)
        {            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;

        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Guilherme" + i,
                LastName = "Horst" + i,
                Address = "Rua Amendoins" + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person {
                Id = 1,
                FirstName = "Guilherme",
                LastName = "Horst",
                Address = "Rua Amendoins",
                Gender = "Male"
            };            
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
