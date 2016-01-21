using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data.Configuration;

namespace PaletteModule.Data.EntityFramework
{
    public class PaletteModuleEFDataConnection
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteModuleEFDataConnection" /> class.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="dataProvider">The data provider.</param>
        private PaletteModuleEFDataConnection(string connectionName, string connectionString, IPaletteModuleEFDataProvider dataProvider)
        {
            this.connectionName = connectionName;
            this.connectionString = connectionString;
            this.dataProvider = dataProvider;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the name of the connection.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return this.connectionName;
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Initializes the connection.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <param name="dataProvider">The data provider.</param>
        /// <returns></returns>
        public static PaletteModuleEFDataConnection InitializeConnection(string connectionName, IPaletteModuleEFDataProvider dataProvider)
        {
            IConnectionStringSettings connectionSettings = PaletteModuleEFDataConnection.GetConnectionStringSettings(connectionName);

            PaletteModuleEFDataConnection connection;
            if (!PaletteModuleEFDataConnection.connections.TryGetValue(connectionSettings.Name, out connection))
            {
                lock (PaletteModuleEFDataConnection.connectionsLock)
                {
                    if (!PaletteModuleEFDataConnection.connections.TryGetValue(connectionSettings.Name, out connection))
                    {
                        connection = new PaletteModuleEFDataConnection(connectionSettings.Name, connectionSettings.ConnectionString, dataProvider);
                        PaletteModuleEFDataConnection.connections.Add(connectionSettings.Name, connection);
                    }
                }
            }
            return connection;
        }

        /// <summary>
        /// Gets the entity framework context.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static PaletteModuleEFDbContext GetContext(string connectionName, IPaletteModuleEFDataProvider provider)
        {
            PaletteModuleEFDataConnection connection;

            if (!connections.TryGetValue(connectionName, out connection))
                connection = InitializeConnection(connectionName, provider);

            return new PaletteModuleEFDbContext(connection.connectionString);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Gets the connection string settings.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <returns></returns>
        private static IConnectionStringSettings GetConnectionStringSettings(string connectionStringName)
        {
            DataConfig dataConfig = Config.Get<DataConfig>();

            if (!dataConfig.ConnectionStrings.ContainsKey(connectionStringName))
                throw new KeyNotFoundException(connectionStringName);

            return dataConfig.ConnectionStrings[connectionStringName];
        }
        #endregion

        #region Private members
        private static readonly IDictionary<string, PaletteModuleEFDataConnection> connections = new Dictionary<string, PaletteModuleEFDataConnection>();
        private static readonly object connectionsLock = new object();
        private readonly IPaletteModuleEFDataProvider dataProvider;
        private readonly string connectionName;
        private string connectionString;
        #endregion
    }
}