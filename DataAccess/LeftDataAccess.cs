using Dapper;
using Microsoft.Data.Sqlite;
using Robo.Models.Left;
using SQLitePCL;
using System.Data;

namespace Robo.DataAccess
{
    public class LeftDataAccess
    {
        private readonly string _connectionString;

        public LeftDataAccess(string connectionString)
        {
            _connectionString = connectionString;
            Batteries.Init(); // Inicializa o provedor SQLite
        }

        private IDbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
        }

        public int ExecuteUpdate_Left_Arm(LeftArm leftArm)
        {
            try
            {
                using var connection = CreateConnection();

                var parameters = new
                {
                    LA_Rest = leftArm.LARest,
                    LA_Contracted1 = leftArm.LAContracted1,
                    LA_Contracted2 = leftArm.LAContracted2,
                    LA_Contracted3 = leftArm.LAContracted3
                };
                return connection.Execute("UPDATE Left_Arm SET LA_Rest = @LA_Rest, LA_Contracted1 = @LA_Contracted1, LA_Contracted2 = @LA_Contracted2, LA_Contracted3 = @LA_Contracted3", parameters);
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
                return connection.Execute("UPDATE Left_Pulse SET LP_90 = @LP_90, LP_45 = @LP_45, LP_0 = @LP_0, LP_45_ = @LP_45_, LP_90_ = @LP_90_, LP_135 = @LP_135, LP_180 = @LP_180", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
