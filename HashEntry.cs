using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap
{
    public class HashEntry
    {
        private readonly long Key;
        private string Value;

        public long GetKey()
        {
            return this.Key;
        }

       public void SetValue(string value)
        {
            Value = value;
        }

        public string GetValue()
        {
            return Value;
        }

      

        public HashEntry(long key, string value)
        {
            Key = key;
            Value = value;
        }


    }
}
