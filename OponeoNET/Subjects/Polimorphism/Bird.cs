using System;

namespace OponeoNET.Subjects.Polimorphism
{
    public class Bird : Animal, IFlyingAnimal
    {
        public void Flying()
        {
            Console.WriteLine("I can fly!");
        }

        public void Voice()
        {
            Console.WriteLine("Kra kra!");
        }

        public override void DoSomething()
        {
            Console.WriteLine("Zupelnie co innego");
            base.DoSomething();
        }
    }
}
