using Robo.DataAccess;
using Robo.Models.Arm;
using Robo.Models.Hand;
using Robo.Models.Left;

namespace Robo.Services
{
    public class LeftService
    {
        private readonly HandDataAccess _dataAccess;

        public LeftService(HandDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public int UpdateRightPulse(RightPulse rightPulse)
        {
            // Aqui você pode adicionar lógica de verificação, se necessário
            return _dataAccess.ExecuteUpdate_Right_Pulse(rightPulse);
        }

        public int UpdateLeftPulse(LeftPulse leftPulse)
        {
            // Aqui você pode adicionar lógica de verificação, se necessário
            return _dataAccess.ExecuteUpdate_Left_Pulse(leftPulse);
        }
    }
}
