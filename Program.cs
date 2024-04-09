﻿using System;
using System.IO;

/*
    The only purpose of this program is to let Dotnet build a platform 
    specific library for SQLite3 that can be used in Opensimulator.

    All the program does when run is to create a connection to a data
    source in memory, which in turn will be closed again without doing
    anything.

    See more information in the README.md.
*/

using Microsoft.Data.Sqlite;

namespace Sqlite3Driver
{
    class Program
    {
        static void Main()
        {
            using (var connection = new SqliteConnection("Data Source=:memory:"))
            {
                connection.Open();
            }
            Console.WriteLine ("Opened an SQLite3 connection into memory.");
            
            // Clean up
            File.Delete(":memory:");

                Console.WriteLine ("Looks good - cleaned up and done.");
        
            
        }
    }
}