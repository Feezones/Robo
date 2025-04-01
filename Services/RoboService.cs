using Robo.DataAccess;
using Robo.Models.Head;
using Robo.Models.Left;
using Robo.Models.Right;
using System.Collections.Generic;

namespace Robo.Services
{
    public class RoboService
    {
        private readonly RoboDataAccess _dataAccess;

        public RoboService(RoboDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public int UpdateHeadRotation(HeadRotation headRotation)
        {
            // Aqui você pode adicionar lógica de verificação, se necessário
            return _dataAccess.ExecuteUpdate_Head_Rotation(headRotation);
        }

        public int UpdateHeadTilt(HeadTilt headTilt)
        {
            // Aqui você pode adicionar lógica de verificação, se necessário
            return _dataAccess.ExecuteUpdate_Head_Tilt(headTilt);
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
