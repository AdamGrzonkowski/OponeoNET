using System.Threading;

namespace OponeoNET.Subjects.Polimorphism
{
    public abstract class Animal
    {
        public virtual void DoSomething()
        {
            Thread.Sleep(1);
        }

        public virtual void DoSomething(string num)
        {
            DoSomething();
            Thread.Sleep(1);
        }

        public virtual void DoSomething(string num, int cosTam)
        {
            DoSomething(num);
        }

        public virtual void DoSomething(string num, int cosTam, bool fsds)
        {
            DoSomething(num, cosTam);
        }
    }
}
