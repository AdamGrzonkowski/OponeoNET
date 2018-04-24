using OponeoNET.Subjects.Polimorphism.Zadanie.Base;
using OponeoNET.Subjects.Polimorphism.Zadanie.Entities;
using System;

namespace OponeoNET.Subjects.Polimorphism.Zadanie.Services
{
    public class AdminService : BaseService<Admin>, IAdminService
    {
        public override Guid Create()
        {
            Guid id = base.Create();

            Console.WriteLine($"New Admin created with Id: {id} at {DateTime.Now}");
            return id;
        }

        public void Delete(Guid id)
        {
            Collection.RemoveAll(x => x.Id == id);
        }

        public void Update(Admin adm)
        {
            Admin updated = Collection.Find(x => x.Id == adm.Id);
            updated.SomeProperty = adm.SomeProperty;

            Console.WriteLine($"{nameof(Admin)} updated with Id: {updated.Id} at {DateTime.Now}");
        }
    }
}
