using Dapper;
using Microsoft.Data.Sqlite;
using Robo.Models.Right;
using SQLitePCL;
using System.Data;

namespace Robo.DataAccess
{
    public class RightDataAccess
    {
        private readonly string _connectionString;

        public RightDataAccess(string connectionString)
        {
            _connectionString = connectionString;
            Batteries.Init(); // Inicializa o provedor SQLite
        }

        private IDbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
        }

        public int ExecuteUpdate_Right_Arm(RightArm rightArm)
        {
            try
            {
                using var connection = CreateConnection();

                var parameters = new
                {
                    RA_Rest = rightArm.RARest,
                    RA_Contracted1 = rightArm.RAContracted1,
                    RA_Contracted2 = rightArm.RAContracted2,
                    RA_Contracted3 = rightArm.RAContracted3
                };
                return connection.Execute("UPDATE Right_Arm SET RA_Rest = @RA_Rest, RA_Contracted1 = @RA_Contracted1, RA_Contracted2 = @RA_Contracted2, RA_Contracted3 = @RA_Contracted3", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteUpdate_Right_Pulse(RightPulse rightPulse)
        {
            try
            {
                using var connection = CreateConnection();

                var parameters = new
                {
                    RP_90 = rightPulse.RP90,
                    RP_45 = rightPulse.RP45,
                    RP_0 = rightPulse.RP0,
                    RP_45_ = rightPulse.RP45_,
                    RP_90_ = rightPulse.RP90_,
                    RP_135 = rightPulse.RP135,
                    RP_180 = rightPulse.RP180
                };
                return connection.Execute("UPDATE Right_Pulse SET RP_90 = @RP_90, RP_45 = @RP_45, RP_0 = @RP_0, RP_45_ = @RP_45_, RP_90_ = @RP_90_, RP_135 = @RP_135, RP_180 = @RP_180", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
