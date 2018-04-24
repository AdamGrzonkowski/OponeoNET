using OponeoNET.Subjects.Polimorphism.Zadanie.Base;
using OponeoNET.Subjects.Polimorphism.Zadanie.Entities;
using System;

namespace OponeoNET.Subjects.Polimorphism.Zadanie.Services
{
    public class ModeratorService : BaseService<Moderator>, IModeratorService
    {
        public void Update(Moderator adm)
        {
            Moderator updated = Collection.Find(x => x.Id == adm.Id);
            if (updated == null)
            {
                return;
            }
            updated.ForumName = adm.ForumName;

            Console.WriteLine($"{nameof(Moderator)} updated with Id: {updated.Id} at {DateTime.Now}");
        }
    }
}
