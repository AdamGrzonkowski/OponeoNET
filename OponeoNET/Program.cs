using OponeoNET.Subjects.Polimorphism.Zadanie;

namespace OponeoNET
{
    public class Program
    {
        static void Main(string[] args)
        {
            IPolimorphismTest poli = new PolimorphismTest();
            poli.CheckPolimorphism();
        }
    }
}
