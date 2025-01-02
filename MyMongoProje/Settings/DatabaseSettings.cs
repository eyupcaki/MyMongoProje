﻿namespace MyMongoProje.Settings
{
    public class DatabaseSettings :IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string ProductCollectionName { get; set; }

    }
}