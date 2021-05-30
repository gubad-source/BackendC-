using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Backend_Project.Concrate
{
    interface ISaved
    {
        void Save(string path);
        void Load(string path);
    }
}
