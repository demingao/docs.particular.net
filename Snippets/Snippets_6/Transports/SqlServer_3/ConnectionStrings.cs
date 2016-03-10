﻿namespace Snippets5.Transports.SqlServer
{
    using System.Data.SqlClient;
    using NServiceBus;
    using NServiceBus.Transports.SQLServer;

    public class NamedConnectionString
    {
		void ConnectionString()
        {
            EndpointConfiguration endpointConfiguration = new EndpointConfiguration();
            #region sqlserver-config-connectionstring

            endpointConfiguration.UseTransport<SqlServerTransport>()
                .ConnectionString("Data Source=INSTANCE_NAME;Initial Catalog=some_database;Integrated Security=True");

            #endregion
        }
		
        void ConnectionName()
        {
            EndpointConfiguration endpointConfiguration = new EndpointConfiguration();
            #region sqlserver-named-connection-string

            endpointConfiguration.UseTransport<SqlServerTransport>()
                .ConnectionStringName("MyConnectionString");

            #endregion
        }

        void ConnectionFactory()
        {
            EndpointConfiguration endpointConfiguration = new EndpointConfiguration();
            #region sqlserver-custom-connection-factory 3

            endpointConfiguration.UseTransport<SqlServerTransport>()
                .UseCustomSqlConnectionFactory(async () =>
                {
                    SqlConnection connection = new SqlConnection(@"Server=localhost\sqlexpress;Database=nservicebus;Trusted_Connection=True;");
                    await connection.OpenAsync();
                    return connection;
                });

            #endregion
        }
    }
}