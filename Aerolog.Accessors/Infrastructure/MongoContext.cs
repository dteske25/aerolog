using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using Nest;

namespace Aerolog.Accessors.Infrastructure
{
    public class MongoContext
    {
        public MongoClient Client { get; }
        public IMongoDatabase Database { get; }

        public MongoContext(string connectionString, string databaseName)
        {
            Client = new MongoClient(connectionString);
            Database = Client.GetDatabase(databaseName);
        }
    }
}
