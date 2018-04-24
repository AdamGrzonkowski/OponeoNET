using System.Collections.Generic;

namespace OponeoNET.Subjects.Polimorphism
{
    public class CallingMethod
    {
        public void CheckOutPolimorphism()
        {
            IRunningAnimal a1 = new Dog();
            a1.Voice();
            a1 = new Cat();
            a1.Voice();
            Bird a3 = new Bird();

            List<IAnimal> aCol = new List<IAnimal>();
            aCol.Add(a1);
            aCol.Add(a3);

            foreach (var a in aCol)
            {
                a.Voice();
            }

            a1.Run();
            a3.Flying();

            (new Cat()).DoSomething();
            a3.DoSomething();

            Creator<Dog> creator = new Creator<Dog>();
            creator.CreateNew().Voice();
        }
    }
}
