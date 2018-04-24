using OponeoNET.Subjects.Polimorphism.Zadanie.Entities;
using OponeoNET.Subjects.Polimorphism.Zadanie.Services;
using System;

namespace OponeoNET.Subjects.Polimorphism.Zadanie
{
    public class PolimorphismTest : IPolimorphismTest
    {
        public void CheckPolimorphism()
        {
            IUsersService usrService = new UsersService();
            usrService.Read();

            IModeratorService modService = new ModeratorService();
            modService.Update(new Moderator());

            IAdminService admService = new AdminService();
            Guid newAdmin = admService.Create();
            admService.Delete(newAdmin);
        }
    }
}
