using Robo.DataAccess;
using Robo.Models.Head;

namespace Robo.Services
{
    public class HeadService
    {
        private readonly HeadDataAccess _dataAccess;

        public HeadService(HeadDataAccess dataAccess)
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
    }
}
