﻿namespace MyMongoProje.Settings
{
    public interface IDatabaseSettings
    {
        public  string ConnectionString { get; set; }
        public  string DatabaseName { get; set; }
        public  string CustomerCollectionName { get; set; }
        public  string ProductCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
    }
}
