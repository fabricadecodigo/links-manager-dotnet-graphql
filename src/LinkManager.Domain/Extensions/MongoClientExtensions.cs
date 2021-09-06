using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using System;

namespace LinkManager.Domain.Extensions
{
    public static class MongoClientExtensions
    {
        public static IServiceCollection AddMongoDbClient(this IServiceCollection services, IConfiguration configuration)
        {
            var conventions = new ConventionPack
            {
                new CamelCaseElementNameConvention(),
                new EnumRepresentationConvention(BsonType.String),
                new IgnoreIfNullConvention(true),
                new IgnoreExtraElementsConvention(true)
            };

            ConventionRegistry.Register("MongoConvention", conventions, _ => true);
            BsonSerializer.RegisterIdGenerator(typeof(Guid), CombGuidGenerator.Instance);

            return services.AddSingleton(_ =>
            {
                var cluster = configuration.GetConnectionString("MONGODB_CLUSTER");
                var user = configuration.GetConnectionString("MONGODB_USER");
                var password = configuration.GetConnectionString("MONGODB_PASSWORD");
                var database = configuration.GetConnectionString("MONGODB_DATABASE");

                var url = $"mongodb+srv://{user}:{password}@{cluster}/${database}?retryWrites=true&w=majority";
                var mongoUrl = new MongoUrl(url);
                var client = MongoClientSettings.FromUrl(mongoUrl);

                return new MongoClient(client);
            });
        }
    }
}