using OponeoNET;

namespace UnitTests.Testers
{
    public class ProtectedPropsTestingTester : ProtectedPropsTesting
    {
        public new int ConvertToInt(double x)
        {
            return base.ConvertToInt(x);
        }
    }
}
