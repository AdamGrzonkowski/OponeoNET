using System;

namespace OponeoNET.Subjects.Polimorphism
{
    public class Cat : Animal, IRunningAnimal
    {
        public void Run()
        {
            Console.WriteLine("dog runs");
        }

        public void Voice()
        {
            Console.WriteLine("Miau!");
        }
    }
}
