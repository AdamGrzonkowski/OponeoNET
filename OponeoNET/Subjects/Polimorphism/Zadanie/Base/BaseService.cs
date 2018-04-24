using System;
using System.Collections.Generic;

namespace OponeoNET.Subjects.Polimorphism.Zadanie.Base
{
    public abstract class BaseService<T> where T : BaseEntity
    {
        /// <summary>
        /// Mock collection.
        /// </summary>
        protected readonly List<T> Collection = new List<T>
        {
            CreateNewInstance(),
            CreateNewInstance(),
            CreateNewInstance()
        };

        public virtual Guid Create()
        {
            T entity = CreateNewInstance();
            Collection.Add(entity);
            return entity.Id;
        }

        private static T CreateNewInstance()
        {
            return Activator.CreateInstance<T>();
        }

        public virtual void Read()
        {
            foreach(var item in Collection)
            {
                //TODO: some code when reading
            }
        }
    }
}
