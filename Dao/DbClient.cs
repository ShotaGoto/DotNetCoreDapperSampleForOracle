using Dapper;
using System.Collections.Generic;
using System.Data.Common;

namespace Dao
{
    public class DbClient
    {
        //接続情報保持用
        private DbConnection Connection { get; } = new Oracle.ManagedDataAccess.Client.OracleConnection();

        //コンストラクタ
        public DbClient()
        {
            //ここで接続情報を設定する
            Connection.ConnectionString = @"Data Source = (DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=192.168.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=hoge))) ; User ID = foo; Password = tiger;";
            //接続開始
            Connection.Open();
        }

        public IEnumerable<T> Select<T>(string sql, T param)
        {
            return Connection.Query<T>(sql, param);
        }

        public void Update<T>(string sql, T param)
        {
            using (var trun = Connection.BeginTransaction())
            {
                Connection.Execute(sql, param);

                trun.Commit();
            }
        }
    }
}