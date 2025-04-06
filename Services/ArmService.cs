using Robo.DataAccess;
using Robo.Models.Arm;
using Robo.Models.Hand;
using Robo.Models.Right;

namespace Robo.Services
{
    public class ArmService
    {
        private readonly ArmDataAccess _dataAccess;

        public ArmService(ArmDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }


        public int UpdateRightArm(RightArm rightArm)
        {
            // Aqui você pode adicionar lógica de verificação, se necessário
            return _dataAccess.ExecuteUpdate_Right_Arm(rightArm);
        }

        public int UpdateLeftArm(LeftArm leftArm)
        {
            // Aqui você pode adicionar lógica de verificação, se necessário
            return _dataAccess.ExecuteUpdate_Left_Arm(leftArm);
        }
    }
}
