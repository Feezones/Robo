using Microsoft.Data.Sqlite;
using System.Data;
using Dapper;
using Robo.Models.Head;
using SQLitePCL;
using Robo.Models.Left;
using Robo.Models.Right;

namespace Robo.DataAccess
{
    public class RoboDataAccess
    {
        private readonly string _connectionString;

        public RoboDataAccess(string connectionString)
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
