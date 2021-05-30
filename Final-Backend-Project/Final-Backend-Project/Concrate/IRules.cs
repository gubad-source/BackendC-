using Final_Backend_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Backend_Project.Concrate
{
    interface IRules<T>
    {
        bool Add(T model);
        bool Remove(T model);
    }
}
