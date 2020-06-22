using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ishooper.Dal.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Ishooper.Dal
{

    public class MongoContext : IMongoContext
    {

        private IMongoDatabase Database { get; set; }

        public MongoClient MongoClient { get; set; }

        private readonly List<Func<Task>> _commands;

        public IClientSessionHandle Session { get; set; }

        public MongoContext(IConfiguration configuration)
        {
            // Set Guid to CSharp style (with dash -)
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();

            RegisterConventions();

            // Configure mongo (You can inject the config, just to simplify)
            MongoClient = new MongoClient(Environment.GetEnvironmentVariable("MONGOCONNECTION") ?? configuration.GetSection("MongoDatabase").GetSection("ConnectionString").Value);
            
            Database = MongoClient.GetDatabase(Environment.GetEnvironmentVariable("DATABASENAME") ?? configuration.GetSection("MongoDatabase").GetSection("Database").Value);

        }

        private void RegisterConventions()
        {
            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true)
            };
            ConventionRegistry.Register("Laborx Conventions", pack, t => true);
        }

        public async Task<int> SaveChanges()
        {
            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return _commands.Count;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            while (Session != null && Session.IsInTransaction)
                Thread.Sleep(TimeSpan.FromMilliseconds(500));

            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

    }
}
