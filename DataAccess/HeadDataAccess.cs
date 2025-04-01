using Microsoft.Data.Sqlite;
using System.Data;
using Dapper;
using Robo.Models.Head;
using SQLitePCL;
using Robo.Models.Left;
using Robo.Models.Right;

namespace Robo.DataAccess
{
    public class HeadDataAccess
    {
        private readonly string _connectionString;

        public HeadDataAccess(string connectionString)
        {
            _connectionString = connectionString;
            Batteries.Init(); // Inicializa o provedor SQLite
        }

        private IDbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
        }

        public int ExecuteUpdate_Head_Rotation(HeadRotation headRotation)
        {
            try
            {
                using var connection = CreateConnection();

                var parameters = new
                {
                    R_90 = headRotation.R90,
                    R_45 = headRotation.R45,
                    R_0 = headRotation.R0,
                    R_45_ = headRotation.R45_,
                    R_90_ = headRotation.R90_
                };
                return connection.Execute("UPDATE Head_Rotation SET R_90 = @R_90, R_45 = @R_45, R_0 = @R_0, R_45_ = @R_45_, R_90_ = @R_90_", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteUpdate_Head_Tilt(HeadTilt headTilt)
        {
            try
            {
                using var connection = CreateConnection();

                var parameters = new
                {
                    L_Up = headTilt.LUp,
                    L_Rest = headTilt.LRest,
                    L_Down = headTilt.LDown
                };
                return connection.Execute("UPDATE Head_Tilt SET L_Up = @L_Up, L_Rest = @L_Rest, L_Down = @L_Down", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
