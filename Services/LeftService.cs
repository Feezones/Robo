using Robo.DataAccess;
using Robo.Models.Left;

namespace Robo.Services
{
    public class LeftService
    {
        private readonly LeftDataAccess _dataAccess;

        public LeftService(LeftDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public int UpdateLeftArm(LeftArm leftArm)
        {
            // Aqui você pode adicionar lógica de verificação, se necessário
            return _dataAccess.ExecuteUpdate_Left_Arm(leftArm);
        }

        public int UpdateLeftPulse(LeftPulse leftPulse)
        {
            // Aqui você pode adicionar lógica de verificação, se necessário
            return _dataAccess.ExecuteUpdate_Left_Pulse(leftPulse);
        }
    }
}
