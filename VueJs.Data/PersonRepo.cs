using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueJs.Data
{
    public class PersonRepo
    {
        public IEnumerable<Person> GetPeople()
        {
            using (var context = new PersonsDataContext())
            {
                return context.Persons.ToList();
            }
        }

        public void AddPerson(Person person)
        {
            using (var context = new PersonsDataContext())
            {
                context.Persons.InsertOnSubmit(person);
                context.SubmitChanges();
            }
        }

        public void Update(Person person)
        {
            using (var context = new PersonsDataContext())
            {
                context.Persons.Attach(person);
                context.Refresh(RefreshMode.KeepCurrentValues, person);
                context.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new PersonsDataContext())
            {
                context.ExecuteCommand("DELETE FROM People WHERE Id = {0}", id);
            }
        }
    }
}
