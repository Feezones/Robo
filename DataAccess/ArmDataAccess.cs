using Dapper;
using Microsoft.Data.Sqlite;
using Robo.Models.Arm;
using Robo.Models.Hand;
using Robo.Models.Right;
using SQLitePCL;
using System.Data;

namespace Robo.DataAccess
{
    public class ArmDataAccess
    {
        private readonly string _connectionString;

        public ArmDataAccess(string connectionString)
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
                return connection.Execute("UPDATE RightArm SET RA_Rest = @RA_Rest, RA_Contracted_1 = @RA_Contracted1, RA_Contracted_2 = @RA_Contracted2, RA_Contracted_3 = @RA_Contracted3", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                return connection.Execute("UPDATE LeftArm SET LA_Rest = @LA_Rest, LA_Contracted_1 = @LA_Contracted1, LA_Contracted_2 = @LA_Contracted2, LA_Contracted_3 = @LA_Contracted3", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
