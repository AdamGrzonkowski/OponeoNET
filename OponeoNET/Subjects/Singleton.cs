using System;

namespace OponeoNET.Subjects
{
    /// <summary>
    /// Singleton pattern implemented using double-checked pattern (locking).
    /// </summary>
    public class SingletonDoubleLocking
    {
        private static SingletonDoubleLocking _instance;
        private static readonly object _lockObject = new object();

        private SingletonDoubleLocking()
        {
        }

        public static SingletonDoubleLocking GetInstance()
        {
            if (_instance == null)
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonDoubleLocking();
                    }
                }
            }

            return _instance;
        }
    }

    /// <summary>
    /// Version using Lazy<> class introduced in .NET v4.0. Lazy implements underneath double-checked pattern. This code is in fact the same as the one in SingletonDoubleLocking class.
    /// </summary>
    public class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> _lazy = new Lazy<SingletonLazy>(() => new SingletonLazy());
        public static SingletonLazy Instance => _lazy.Value;

        private SingletonLazy()
        {
        }
    }
}