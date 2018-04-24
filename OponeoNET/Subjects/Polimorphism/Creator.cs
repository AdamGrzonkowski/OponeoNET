using System;

namespace OponeoNET.Subjects.Polimorphism
{
    public class Creator<T>
    {
        public T CreateNew()
        {
            Console.WriteLine($"Object created {typeof(T)}");
            return Activator.CreateInstance<T>();
        }
    }
}
