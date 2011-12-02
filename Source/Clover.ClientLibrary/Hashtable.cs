using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clover.ClientLibrary
{
    public class Hashtable : IDisposable
    {
        /// <summary>
        /// Set the key with value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string key, object value)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Set the key with value and expire
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        public void SetWithExpire(string key, object value, TimeSpan ts)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Set the key with value only when the key hasn't modified by anyother
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="oldValue"></param>
        /// <returns></returns>
        public bool SetWithVersion(string key, object value, out object oldValue)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get the value associate with the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            throw new NotImplementedException();
        }
        

        public void Dispose()
        {
            // throw new NotImplementedException();
        }
    }
}
