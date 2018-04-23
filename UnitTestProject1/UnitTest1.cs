using NUnit.Framework;
using OponeoNET.Subjects;
using UnitTests.Testers;

namespace UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        ProtectedPropsTestingTester classToTest = new ProtectedPropsTestingTester();
        ProtectedPropsTesting protectedClass = new ProtectedPropsTesting();

        [Test]
        public void TestMethod1()
        {        
            classToTest.ConvertToInt(2); // we can call protected method from Tester class and properly test it now
            //protectedClass.ConvertToInt(2); // we can't call protected method from main class
        }
    }
}
