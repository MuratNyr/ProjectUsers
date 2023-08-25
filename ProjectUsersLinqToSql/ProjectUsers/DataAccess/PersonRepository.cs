using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUsers.DataAccess
{
    public class PersonRepository
    {
        private readonly DbManagerByLinqToSqlDataContext context;

        public PersonRepository()
        {
            context = new DbManagerByLinqToSqlDataContext();
        }
        public People GetPeopleById(int id)
        {
            var people = context.People.FirstOrDefault(p => p.ID == id);
            return people;
        }

        public List<People> GetAllPeople(string searchText)
        {
            return context.People
                .Where(p => p.Name.Contains(searchText) || p.Surname.Contains(searchText))
                .OrderBy(p => p.Name)
                .ToList();
        }

        public void AddPerson(People newPeople)
        {
            context.People.InsertOnSubmit(newPeople);
            context.SubmitChanges();
        }

        public void UpdatePerson(People peopleToUpdate)
        {
            var existingPerson = context.People.SingleOrDefault(p => p.ID == peopleToUpdate.ID);
            if (existingPerson != null)
            {
                existingPerson.Name = peopleToUpdate.Name;
                existingPerson.Surname = peopleToUpdate.Surname;
                existingPerson.Birthdate = peopleToUpdate.Birthdate;
                existingPerson.Email = peopleToUpdate.Email;
                existingPerson.PhoneNumber = peopleToUpdate.PhoneNumber;
                existingPerson.Address = peopleToUpdate.Address;
                existingPerson.City = peopleToUpdate.City;
                existingPerson.Country = peopleToUpdate.Country;
                existingPerson.PhotoUrl = peopleToUpdate.PhotoUrl;

                context.SubmitChanges();
            }
        }

        public void DeletePerson(int personID)
        {
            var personToDelete = context.People.SingleOrDefault(p => p.ID == personID);
            if (personToDelete != null)
            {
                context.People.DeleteOnSubmit(personToDelete);
                context.SubmitChanges();
            }
        }
    }
}
