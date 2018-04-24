using System;

namespace OponeoNET.Subjects.Polimorphism.Zadanie.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Just to show that we can still call abstract constructor, even though we can't have its instance.
        /// </summary>
        protected BaseEntity()
        {
            GetGuid(); 
        }

        /// <summary>
        /// This will usually go in some Create method. It's here just to show that we can call it even in constructor. :-)
        /// </summary>
        protected virtual void GetGuid()
        {
            if (Id != Guid.Empty && Id != null)
            {
                return;
            }

            Id = Guid.NewGuid();
        }
    }
}
