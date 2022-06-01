﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetSwagOrderingApp
{
   
        public static class Constantcs
        {
            public const string DatabaseFilename = "NetSwagSQLite.db3";
            public const SQLite.SQLiteOpenFlags Flags =
                // open the database in read/write mode
                SQLite.SQLiteOpenFlags.ReadWrite |
                // create the database if it doesn't exist
                SQLite.SQLiteOpenFlags.Create |
                // enable multi-threaded database access
                SQLite.SQLiteOpenFlags.SharedCache;
            public static string DatabasePath
            {
                get
                {
                    var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    return Path.Combine(basePath, DatabaseFilename);
                }
            }
        }
    
}
