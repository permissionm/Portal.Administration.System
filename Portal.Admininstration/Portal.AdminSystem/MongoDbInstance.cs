using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MongoDB.Driver;

namespace Portal.AdminSystem
{
    public class MongoDbInstance
    {
        internal static string MongoDbConnectionString = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;


        public static IMongoCollection<T> GetMongoCollection<T>(string databasename, string collectionname)
        {
            var client = new MongoClient(MongoDbConnectionString);
            return client.GetDatabase(databasename).GetCollection<T>(collectionname);
        }

    }

}
