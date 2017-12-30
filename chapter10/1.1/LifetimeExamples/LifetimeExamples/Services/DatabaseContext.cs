using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifetimeExamples.Services
{
    public class DatabaseContext 
    {
        static readonly Random _rand = new Random();
        public DatabaseContext()
        {
            //The class will return the same random number for its lifetime
            RowCount = _rand.Next(1, 1_000_000_000);
        }

        public int RowCount { get; }
    }

    public class TransientDataContext : DatabaseContext { }
    public class ScopedDataContext : DatabaseContext { }
    public class SingletonDataContext : DatabaseContext { }

}
