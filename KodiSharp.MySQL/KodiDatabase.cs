using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace KodiSharp.MySQL
{
    public class KodiDatabase
    {
        private readonly string _connectionString;

        private IDbConnection _connection;

        public KodiDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbTransaction BeginTransaction()
        {
            EnsureConnected();
            return _connection.BeginTransaction();
        }

        private void EnsureConnected()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new MySqlConnection(_connectionString);
                _connection.Open();
            }
        }

        private int RunNonQuery(IDbTransaction transaction, IDbConnection conn, string text, IDictionary<string, object> parameters = null)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = text;
                cmd.Transaction = transaction;

                if (parameters != null)
                    foreach (var parameter in parameters)
                    {
                        var dbParameter = cmd.CreateParameter();
                        dbParameter.ParameterName = $"@{parameter.Key}";
                        dbParameter.Value = parameter.Value;
                        cmd.Parameters.Add(dbParameter);
                    }

                return cmd.ExecuteNonQuery();
            }
        }

        public int FindRenamePaths(IDbTransaction transaction, string source, string target)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrWhiteSpace(target))
                throw new ArgumentNullException(nameof(target));

            if (!source.StartsWith("smb://"))
                throw new ArgumentException();

            if (!target.StartsWith("smb://"))
                throw new ArgumentException();

            var cmds = new[] {
               "UPDATE path SET strPath = replace(strPath, @source, @target);",
               "UPDATE episode SET c18 = replace(c18, @source, @target);",
               "UPDATE art SET url = replace(url, @source, @target);",
               "UPDATE movie SET c22 = replace(c22, @source, @target);"
            };

            var parameters = new Dictionary<string, object>
            {
                { "source", source },
                { "target", target }
            };

            var rowsChanged = 0;

            foreach (var cmd in cmds)
                rowsChanged += RunNonQuery(transaction, _connection, cmd, parameters);

            return rowsChanged;
        }
    }
}
