﻿using Aerolog.Accessors;
using Aerolog.Accessors.Infrastructure;
using Aerolog.Core;
using MongoDB.Driver;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAccessors(this IServiceCollection services, string mongoDbConnectionString, string mongoDbName)
        {
            var mongoContext = new MongoContext(mongoDbConnectionString, mongoDbName);
            mongoContext.CreateIndexes();
            services.AddScoped(p => mongoContext);

            services.AddTransient<IFileAccessor, FileAccessor>();
            services.AddTransient<ISeriesAccessor, SeriesAccessor>();
            services.AddTransient<IMissionAccessor, MissionAccessor>();
            services.AddTransient<ILogAccessor, LogAccessor>();
            services.AddTransient<IEventAccessor, EventAccessor>();

            return services;
        }

        public static void CreateIndexes(this MongoContext context)
        {
            // Add indexes here
            // context.AddIndex(Builders<Exercise>.IndexKeys.Text(e => e.Name));
            context.AddIndex(Builders<Log>.IndexKeys.Text(e => e.SpeakerName));
        }

        public static MongoContext AddIndex<T>(this MongoContext context, IndexKeysDefinition<T> keys, CreateIndexOptions options = null)
        {
            context.Database.GetCollection<T>(typeof(T).Name).Indexes.CreateOne(new CreateIndexModel<T>(keys, options));
            return context;
        }
    }
}
