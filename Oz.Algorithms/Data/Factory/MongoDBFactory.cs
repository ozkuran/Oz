using System;
using JetBrains.Annotations;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Oz.Algorithms.Data.Factory
{
    /// <summary> MongoDBFactory class 
    /// <para>MongoDBFactory class for data communication with MongoDB databases</para>
    /// <para>Mahmut Ali ÖZKURAN
    /// 16.02.2015
    /// ver. 0.0.1.2
    /// </para>
    /// </summary>
    public class MongoDBFactory
    {
        private string _serverName = "";
        private string _serverPort = "";
        private string _userName = "";
        private string _password = "";
        private string _database = "";
        private string _connectionString = "";
        [UsedImplicitly] private MongoCredential _credential = null;
        [UsedImplicitly] private MongoClient _mongoClient = null;
        private MongoDatabase _mongoDatabase = null;



        /// <summary> MongoDBFactory constructor method 
        /// <para>MongoDBFactory constructor</para>
        /// <para>Mahmut Ali ÖZKURAN
        /// 16.02.2015
        /// ver. 0.0.1.1
        /// </para>
        /// </summary>
        public MongoDBFactory(string serverName = "", string serverPort = "", string userName = "", string password = "", string database = "")
        {
            if (serverName == "")
            {
                _serverName = "localhost";
            }
            else
            {
                _serverName = serverName;
            }
            _serverPort = serverPort;
            _userName = userName;
            _password = password;
            _database = database;
        }

        /// <summary> MongoDBFactory Connect method 
        /// <para>Connecting to MongoDB database with given parameters</para>
        /// <para>Mahmut Ali ÖZKURAN
        /// 16.02.2015
        /// ver. 0.0.1.1
        /// </para>
        /// </summary>
        public bool Connect()
        {
            try
            {
                if (_userName != "")
                {
                    if (_password != "")
                    {
                        _connectionString = "mongodb://" + _userName + ":" + _password + "%40" + _serverName + ":" + _serverPort;
                    }
                }
                else if (_serverPort != "")
                {
                    _connectionString = "mongodb://" + _serverName + ":" + _serverPort;
                }
                else
                {
                    _connectionString = "mongodb://" + _serverName;
                }
                var client = new MongoClient(_connectionString);
                var server = client.GetServer();
                if (_database != "")
                {
                    _mongoDatabase = server.GetDatabase(_database);
                }
                //MongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("stackoverflow.posts");
                return true;
            }
            catch (Exception)
            {
                return false;
                //throw;
            }
        }

        /// <summary> GetCollection method 
        /// <para>Returns given collection from Database</para>
        /// <para>Mahmut Ali ÖZKURAN
        /// 16.02.2015
        /// ver. 0.0.1.1
        /// </para>
        /// </summary>
        public MongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            return _mongoDatabase.GetCollection<BsonDocument>(collectionName);
        } 
    }
}
