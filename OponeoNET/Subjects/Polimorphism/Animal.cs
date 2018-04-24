using System.Threading;

namespace OponeoNET.Subjects.Polimorphism
{
    public abstract class Animal
    {
        public virtual void DoSomething()
        {
            Thread.Sleep(1);
        }
    }
}
