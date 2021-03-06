﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hlp_lab_7_delegates_and_events
{
    class Stack<T> : IСontainer<T>
    {
        private T[] store = new T[0];

        public Stack() { }

        public bool Add(T item)
        {
            int index = this.store.Count();
            Array.Resize(ref this.store, index + 1);
            this.store[index] = item;
            return true;
        }

        public T Remove()
        {
            int index = this.store.Count() - 1;

            if (0 > index)
            {
                throw new Exception("Out of range in stack at index " + index);
            }

            T item = this.store[index];
            Array.Resize(ref this.store, index);
            return item;
        }

        public T Peak()
        {
            return this.store.Last();
        }

        public int Count()
        {
            return this.store.Count();
        }

        public bool Clear()
        {
            this.store = new T[0];
            return true;
        }
    }
}
