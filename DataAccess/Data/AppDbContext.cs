using DataAccess.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class AppDbContext
    {

        private readonly IMongoDatabase mongoDatabase;

        public AppDbContext() 
        { 
            string connStr = Environment.GetEnvironmentVariable("DB_CONN_STR") ?? "mongodb://localhost:27017";
            string database = Environment.GetEnvironmentVariable("DB_NAME_STR") ?? "TodoKanban";
            mongoDatabase = new MongoClient(connStr).GetDatabase(database);
        }

        public MongoCollectionBase<Item> ItemRepo { get { return (MongoCollectionBase<Item>)mongoDatabase.GetCollection<Item>("items");} }

    }
}
