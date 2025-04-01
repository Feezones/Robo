using Robo.DataAccess;
using Robo.Models.Right;

namespace Robo.Services
{
    public class RightService
    {
        private readonly RightDataAccess _dataAccess;

        public RightService(RightDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }


    public int UpdateRightArm(RightArm rightArm)
    {
        // Aqui você pode adicionar lógica de verificação, se necessário
        return _dataAccess.ExecuteUpdate_Right_Arm(rightArm);
    }

    public int UpdateRightPulse(RightPulse rightPulse)
    {
        // Aqui você pode adicionar lógica de verificação, se necessário
        return _dataAccess.ExecuteUpdate_Right_Pulse(rightPulse);
    }
  }
}
