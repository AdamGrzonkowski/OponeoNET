using OponeoNET.Subjects.Polimorphism.Zadanie.Base;
using OponeoNET.Subjects.Polimorphism.Zadanie.Entities;
using System;

namespace OponeoNET.Subjects.Polimorphism.Zadanie.Services
{
    public class UsersService : BaseService<User>, IUsersService
    {
        public override void Read()
        {
            base.Read();
            Console.WriteLine("User read!");
        }
    }
}
