using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using Longsor.Data.Contracts;
using Longsor.Model;

namespace Longsor.Data
{
    public class AvalanchesRepository : IAvalanchesRepository // EFRepository<Avalanche>
    {
        //public AvalanchesRespository(DbContext context) : base(context) {}

        public IQueryable<Avalanche> GetAll()
        {
            const string SQL = "select * from Avalanche";
            var results = new List<Avalanche>();

            using (var cnn = new SqlCeConnection(LongsorDb.ConnectionString))
            using (var cmd = new SqlCeCommand(SQL, cnn))
            {
                cnn.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    results.Add(ToAvalanche(dr));   
                }                
            }
            return new EnumerableQuery<Avalanche>(results);
        }

        private static Avalanche ToAvalanche(IDataRecord record)
        {
            var entity = new Avalanche()
                {
                    Id = (int)record["Id"],
                    Description = record["Description"].ToString()
                };
            return entity;
        }

        public Avalanche GetById(int id)
        {
            var sql = "select * from Avalanche where id = " + id;

            using (var cnn = new SqlCeConnection(LongsorDb.ConnectionString))
            using (var cmd = new SqlCeCommand(sql, cnn))
            {
                cnn.Open();
                var dr = cmd.ExecuteReader();
                return !dr.Read() ? null : ToAvalanche(dr);
            }
        }

        public void Add(Avalanche entity)
        {
            var sql = String.Format("insert into Avalanche (Title, Description) values ('{0}', '{1}');"
                              , entity.Title
                              , entity.Description);

            using (var cnn = new SqlCeConnection(LongsorDb.ConnectionString))
            using (var cmd = new SqlCeCommand(sql, cnn))
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Avalanche entity)
        {
            var sql = String.Format("update Avalanche set Title = '{0}', Description = '{1}' where id = {2};"
                                    , entity.Title
                                    , entity.Description
                                    , entity.Id);

            using (var cnn = new SqlCeConnection(LongsorDb.ConnectionString))
            using (var cmd = new SqlCeCommand(sql, cnn))
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Avalanche entity)
        {
            Delete(entity.Id);
        }

        public void Delete(int id)
        {
            var sql = String.Format("delete Avalanche where id = {0}", id);

            using (var cnn = new SqlCeConnection(LongsorDb.ConnectionString))
            using (var cmd = new SqlCeCommand(sql, cnn))
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
