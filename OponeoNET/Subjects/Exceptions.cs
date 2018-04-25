using System;

namespace OponeoNET.Subjects
{
    public class Exceptions : Exception
    {
        private string _message;

        public Exceptions()
        {
        }

        public Exceptions(string message)
        {
            _message = message;
        }

        public override string Message => _message;
    }
}
