namespace OponeoNET.Subjects
{
    public class ProtectedPropsTesting
    {
        public int SquareThis(double x)
        {
            int y = ConvertToInt(x);
            return y * y;
        }

        protected int ConvertToInt(double x)
        {
            return (int)x;
        }
    }
}
