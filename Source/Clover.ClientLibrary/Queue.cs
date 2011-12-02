using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clover.ClientLibrary
{
    public class Queue : IDisposable
    {
        public Queue(string name)
        {
            
        }

        public void Enqueue(object value)
        {

        }
        public object Dequeue(Type type)
        {
            throw new NotImplementedException();
        }
        public object Dequeue(Type type, int takenum)
        {
            throw new NotImplementedException();
        }
        public T Dequeue<T>()
        {
            throw new NotImplementedException();
        }
        public T Dequeue<T>(int takenum)
        {
            throw new NotImplementedException();
        }
        public object Peek(Type type)
        {
            throw new NotImplementedException();
        }
        public object Peek(Type type, int takenum)
        {
            throw new NotImplementedException();
        }
        public T Peek<T>()
        {
            throw new NotImplementedException();
        }
        public T Peek<T>(int takenum)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // throw new NotImplementedException();
        }
    }
}
