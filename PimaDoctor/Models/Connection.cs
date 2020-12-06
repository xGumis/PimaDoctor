using System.Collections.Generic;
using System.Linq;
using LinqToDB.Configuration;

namespace PimaDoctor.Models
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }

    public class MySettings : ILinqToDBSettings
    {
        public MySettings(bool test)
        {
            if (!test) 
                _connectionString = @"Server=db.polarlooptheory.pl;Port=3306;Database=primadoctor;Uid=studia;Pwd=Studia2020;charset=utf8;";
            else
            {
                _connectionString = @"Server=db.polarlooptheory.pl;Port=3306;Database=primadoctortest;Uid=studia;Pwd=Studia2020;charset=utf8;";
            }
        }
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "MySql.Data.MySqlClient";
        public string DefaultDataProvider => "MySql.Data.MySqlClient";

        private readonly string _connectionString;

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "PrimaDoctor",
                        ProviderName = "MySql.Data.MySqlClient",
                        ConnectionString = _connectionString
                    };
            }
        }
    }
}