using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp6.Model;
using WpfApp6.ViewModel;


namespace WpfApp6.Utils
{
    class DB
    {
        public static async void Connection(PersonsViewModel currerntModelOfPersons)
        {
            IQueryable<users> DATAFromdb = null;
            await Task.Run(() =>
            {
                var context = new gbua_usermapEntities1();
                DATAFromdb = from c in context.users
                             select c;
                List<users> ListFromdb = DATAFromdb.ToList();
            });
            foreach (var personFromDb in DATAFromdb)
            {
                currerntModelOfPersons.Persons.Add(new Person { Id = personFromDb.id.ToString(), Login = personFromDb.login, Pass = personFromDb.password, FirstName = personFromDb.name, LastName = personFromDb.surname, Sex = personFromDb.sex, Age = personFromDb.age,Image=ImageProcess.FromByteToImage(personFromDb.image)});
            }

        }
        public static async void DeleteFormDb(string id)
        {
            await Task.Run(() =>
            {
                var context = new gbua_usermapEntities1();
                users personToDeleteFromDB = new users
                {
                    id = Convert.ToInt32(id)
                };
                context.users.Attach(personToDeleteFromDB);
                context.users.Remove(personToDeleteFromDB);
                context.SaveChanges();
            });
        }




        public static async void AddNew(Person p)
        {
            await Task.Run(() =>
            {
                var context = new gbua_usermapEntities1();
                users userforaddingInDb = new users
                {
                    login = p.Login,
                    password = p.Pass,
                    name = p.FirstName,
                    surname = p.LastName,
                    age = p.Age,
                    sex = p.Sex,
                    image= ImageProcess.imageToByteArray(p.Image),
                    photo = ""
                };
                context.users.Add(userforaddingInDb);
                try
                {
                    context.SaveChanges();
                }
                catch(Exception e)
                {
                    throw new Exception("Validation"+e);
                }
            });

        }
    }

}
