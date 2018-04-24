using System;

namespace OponeoNET.Subjects.Polimorphism
{
    public class Dog : IRunningAnimal
    {
        public void Run()
        {
            Console.WriteLine("dog runs");
        }

        public void Voice()
        {
            Console.WriteLine("Bark!");
        }
    }
}
