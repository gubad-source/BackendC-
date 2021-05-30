using Final_Backend_Project.Concrate;
using Final_Backend_Project.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Final_Backend_Project.Store
{
    class GenericStore<T> : IEnumerable<T>,ISaved,IRules<T>
        where T: IEquatable<T>
    {
        T[] data = null;
        public GenericStore()
        {
            data = new T[0];
        }
        public T this[int index]
        {
            get
            {
                if (index > data.Length)
                {
                    throw new Exception("Mumkun deyil");
                }
                T founded = data[index];
                return founded;
            }

        }


        #region IRules
        public bool Add(T model)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = model;
            return true;
        }

       

        public bool Remove(T model)
        {
            int index = Array.FindIndex(data, m => m.Equals(model));
            if (index == -1)
            {
                return false;
            }
            for(int i = index + 1; i < data.Length; i++)
            {
                data[i - 1] = data[i];
            }
            Array.Resize(ref data, data.Length - 1);
            return true;
        }

        #endregion


        #region Models
        public IEnumerator<T> GetEnumerator()
        {
           foreach(var item in data)
            {
               yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion


        #region ISaved

        public void Save(string path)
        {
           using(var stream=new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bnr = new BinaryFormatter();
                bnr.Serialize(stream, data);
            }
        }


        public void Load(string path)
        {
            if(!File.Exists(path))
            {
                return;
            }

           using(var stream=new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bnr = new BinaryFormatter();
               data=(T[])bnr.Deserialize(stream);
            }
        }
        
        #endregion

    }
}
