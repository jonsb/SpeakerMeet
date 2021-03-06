﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SpeakerMeet.Services;

namespace SpeakerMeet.TestUtils
{
    public class FakeRepository<T> : IRepository<T> where T: IIDentity
    {
        private int _identityCounter = 0;
        public IList<T> DataSet { get; set; }
        
        public T Get(Func<T, bool> predicate)
        {
            return GetAll().AsEnumerable().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return DataSet.AsQueryable();
        }

        public T Save(T item)
        {
            return item.Id == default(int) ? Create(item) : Update(item);
        }

        public IRepository<T> Include(Expression<Func<T, object>> path)
        {
            // Nothing to do here since this function is for Entity Framework.
            // We are using Linq to Objects so there is no need for Include.
            return this;
        }

        private T Create(T item)
        {
            item.Id = ++_identityCounter;
            DataSet.Add(item);
            return item;
        }

        private T Update(T item)
        {
            var found = Get(x => x.Id == item.Id);

            if (found == null)
                throw new KeyNotFoundException($"Item with Id {item.Id} not found");

            DataSet.Remove(found);
            DataSet.Add(item);

            return item;
        }
    }
}