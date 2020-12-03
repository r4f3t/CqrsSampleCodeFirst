﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CqrsSampleFirst.Persistance
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> :
      IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private string CurrentDatabase = "";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";


        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}CqrsSampleFirst.WebApi", Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);


        private TContext Create(string basePath, string environmentName)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            CurrentDatabase = configuration.GetConnectionString("CurrentDatabase");

            var connectionString = configuration.GetConnectionString(CurrentDatabase);


            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{CurrentDatabase}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            if (CurrentDatabase == "PostgreSQLDatabase")
            {
                optionsBuilder.UseNpgsql(connectionString,
                   x =>
                   {
                       x.MigrationsHistoryTable("__MigrationsHistoryOfCore");
                   });
            }

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}
