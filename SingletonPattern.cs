using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A6
{

    // Singleton Desing Pattern

    // ----------------------------------------- ( EXAMPLE 01 ) ------------------------- 

    // using simple method (if condition to make restrictions)
    public sealed class Singleton
    {
        // private instance in class
        private static Singleton instance;
        private static int Id { get; set; } = 0;

        // Private constructor to prevent instantiation outside this class
        private Singleton() { }

        public static Singleton GetInstance()
        {
            // if more than one instance created then the value of
            // prop (Id) becomes incremented

            if (instance == null)
            {
                instance = new Singleton();
                Id++;
            }
            Console.WriteLine("ID:" + Id);
            return instance;
        }

    }

    // ----------------------------------------- ( EXAMPLE 02 ) ------------------------- 
    // using safe thread method

    public sealed class ThreadSafeSingleton
    {
        // Private constructor to prevent instantiation outside this class
        private ThreadSafeSingleton() { }

        // private instance in class
        private static ThreadSafeSingleton instance;

        //lock
        private static readonly object threadLock = new object();
        private static int Id { get; set; } = 0;


        public static ThreadSafeSingleton GetInstance(int id)
        {
            if (instance == null)
            {
                // critical section
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new ThreadSafeSingleton();
                        Id = id;
                        Console.WriteLine("ID:" + id);
                    }
                }
            }
            return instance;
        }

    }
}

