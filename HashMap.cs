using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap
{
    class HashMap
    {
        private static readonly int _tableSize = 177650;
        readonly HashEntry[] table = new HashEntry[_tableSize];

     

       public string Get(long key)
        {
            long i = key % _tableSize;
            int j = 1;
          

            while(table[i].GetKey() != key)
            {
                i = (7 * key + j)% _tableSize;
                j++;
            }
            return table[i].GetValue();

        }

        public string LGet(long key)
        {
            long j = 0;
            long i = (key + j) % _tableSize;

            while (table[i].GetKey() != key)
            {

                j++;

                i = (key + j) % _tableSize;
            }
            return table[i].GetValue();
        }

        public string QGet(long key)
        {
            int k = 0;
            int l = 1;
            int j = (2 * k) + l;
            long i = (key + j) % _tableSize;

            while (table[i].GetKey() != key)
            {

                k++;
                l++;
                i = (key + j) % _tableSize;
                j = (2 * k) + l;


            }
            return table[i].GetValue();
        }

        public void Put(long key, string value)
        {
            HashEntry hashEntry = new HashEntry(key, value);
            long i = key % _tableSize;
            int j = 1;
            if (table[i] == null)
            {
                table[i] = hashEntry;
            }
            else
            {

                while (table[i] != null)
                {
                    i = (7 * key + j)%table.Length;
                    j++;
                    if (i > table.Length)
                    {
                        i = 0;
                        
                        
                    }
                }
            }
            table[i] = hashEntry;

            
           
        }

        public void LinearProbe(long key, string value)
        {
            
            long j = 0;
            HashEntry hashEntry = new HashEntry(key, value);

           long i = (key + j) % _tableSize;
            if (table[i] == null)
            {
                table[i] = hashEntry;
            }

            else
            {

                while (table[i] != null)
                {
                    if (table[i].GetKey() != hashEntry.GetKey())
                    {
                        j++;
                        i = (key + j) % _tableSize;
                        
                    }


                }
            }
            table[i] = hashEntry;
            
        }

        public void QuadraticProbe(long key, string value)
        {
            
            int k = 0;
            int l = 1;
            int j = (2 * k) + l;
            HashEntry hashEntry = new HashEntry(key, value);

            long i = (key + j) % _tableSize;
            if (table[i] == null)
            {
                table[i] = hashEntry;
            }
            else
            {



                while (table[i] != null)
                {
                    if (table[i].GetKey() != hashEntry.GetKey())
                    {
                        k++;
                        l++;
                        i = (key + j) % _tableSize;
                        j = (2 * k) + l;

                    }
                }
            }
            table[i] = hashEntry;
        }

        

    }
}
