using ProjectUsers.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUsers.DataAccess
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext() : base(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString)
        {
        }
        public void UpdatePerson(People updatedPerson)
        {
            People existingPerson = People.Find(updatedPerson.ID);
            if (existingPerson != null)
            {
                existingPerson.Name = updatedPerson.Name;
                existingPerson.Surname = updatedPerson.Surname;
                existingPerson.Birthdate = updatedPerson.Birthdate;
                existingPerson.Email = updatedPerson.Email;
                existingPerson.PhoneNumber = updatedPerson.PhoneNumber;
                existingPerson.Address = updatedPerson.Address;
                existingPerson.City = updatedPerson.City;
                existingPerson.Country = updatedPerson.Country;
                existingPerson.PhotoUrl = updatedPerson.PhotoUrl;

                SaveChanges();
            }
        }

        public DbSet<People> People { get; set; }

        public void AddPerson(People person)
        {
            People.Add(person);
            SaveChanges();
        }

        public void DeletePerson(int id)
        {
            var personToDelete = People.Find(id);
            if (personToDelete != null)
            {
                People.Remove(personToDelete);
                SaveChanges();
            }
        }
        public List<People> SearchPeopleByText(string searchText)
        {
            return People.OrderBy(p => p.Name).Where(p => p.Name.Contains(searchText) || p.Surname.Contains(searchText)).ToList();
        }
        public List<People> GetAllPeople()
        {
            return People.OrderBy(p => p.Name).ToList();
        }
        public People GetPersonById(int id)
        {
            return People.Find(id);
        }
    }
}
