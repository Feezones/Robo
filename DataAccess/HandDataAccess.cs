using Dapper;
using Microsoft.Data.Sqlite;
using Robo.Models.Arm;
using Robo.Models.Hand;
using Robo.Models.Left;
using SQLitePCL;
using System.Data;

namespace Robo.DataAccess
{
    public class HandDataAccess
    {
        private readonly string _connectionString;

        public HandDataAccess(string connectionString)
        {
            _connectionString = connectionString;
            Batteries.Init();
        }

        private IDbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
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
                return connection.Execute("UPDATE RightPulse SET RP_90 = @RP_90, RP_45 = @RP_45, RP_0 = @RP_0, RP_45_ = @RP_45_, RP_90_ = @RP_90_, RP_135 = @RP_135, RP_180 = @RP_180", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteUpdate_Left_Pulse(LeftPulse leftPulse)
        {
            try
            {
                using var connection = CreateConnection();

                var parameters = new
                {
                    LP_90 = leftPulse.LP90,
                    LP_45 = leftPulse.LP45,
                    LP_0 = leftPulse.LP0,
                    LP_45_ = leftPulse.LP45_,
                    LP_90_ = leftPulse.LP90_,
                    LP_135 = leftPulse.LP135,
                    LP_180 = leftPulse.LP180
                };
                return connection.Execute("UPDATE LeftPulse SET LP_90 = @LP_90, LP_45 = @LP_45, LP_0 = @LP_0, LP_45_ = @LP_45_, LP_90_ = @LP_90_, LP_135 = @LP_135, LP_180 = @LP_180", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
