using Ftec.WebAPI.Domain.Entities;
using Ftec.WebAPI.Domain.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.WebAPI.Infra.Repository
{
    public class LocalRepository : ILocalRepository
    {
        private string connectionString;

        public LocalRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public String Insert(Local local)
        {
            //throw new NotImplementedException();

            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                //Inicia a transação
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = con;
                        cmd.Transaction = trans;
                        cmd.CommandText = @"INSERT Into local (id,identificador,latitude,longitude,altitude,speed,accuracy,bearing,data) values(@id,@identificador, @latitude,@altitude, @longitude, @speed,@accuracy,@bearing,@data)";
                        cmd.Parameters.AddWithValue("identificador", local.Identificador);
                        cmd.Parameters.AddWithValue("latitude", local.Latitude);
                        cmd.Parameters.AddWithValue("longitude", local.Longitude);
                        cmd.Parameters.AddWithValue("altitude", local.Altitude);
                        cmd.Parameters.AddWithValue("speed", local.Speed);
                        cmd.Parameters.AddWithValue("accuracy", local.Accuracy);
                        cmd.Parameters.AddWithValue("bearing", local.Bearing);
                        cmd.Parameters.AddWithValue("data", local.Data);
                        Guid id = Guid.NewGuid();
                        cmd.Parameters.AddWithValue("id", id);



                        cmd.ExecuteNonQuery();
                        //commit na transação
                        trans.Commit();
                        return local.Identificador;

                    }
                    catch (Exception ex)
                    {
                        //rollback da transação
                        trans.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
