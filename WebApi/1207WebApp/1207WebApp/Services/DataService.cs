using _1207WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1207WebApp.Services
{
    public class DataService
    {
        private List<PersonModel> persons = new List<PersonModel>();

        public List<PersonModel> GetAll()
        {
            return persons;
        }

        public void Add(PersonModel personModel)
        {
            persons.Add(personModel);
        }
    }
}
