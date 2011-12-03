using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clover.ClientLibrary
{
    public class List
    {
        public void Add(object value)
        {
        }
        public void AddRange(IEnumerable<object> values)
        {
            throw new NotImplementedException();
        }
        public bool Remove(object value)
        {
            throw new NotImplementedException();
        }
        public bool RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
        }
        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }
        public int Count
        {
            get;
        }
        public object this[int index]
        {
            get;
            set;
        }
    }
}
