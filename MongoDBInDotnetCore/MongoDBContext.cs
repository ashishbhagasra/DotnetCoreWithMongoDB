using MongoDBInDotnetCore.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBInDotnetCore
{
    public class MongoDBContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

        private IMongoDatabase _database { get; }

        public MongoDBContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to db server.", ex);
            }
        }

        public IMongoCollection<Post> Posts
        {
            get
            {
                return _database.GetCollection<Post>("Posts");
            }
        }

        public IMongoCollection<SchoolRegistration> SchoolRegistrations
        {
            get
            {
                return _database.GetCollection<SchoolRegistration>("SchoolRegistrations");
            }
        }

        public IMongoCollection<TeacherRegistration> TeacherRegistrations
        {
            get
            {
                return _database.GetCollection<TeacherRegistration>("TeacherRegistrations");
            }
        }
    }
}
