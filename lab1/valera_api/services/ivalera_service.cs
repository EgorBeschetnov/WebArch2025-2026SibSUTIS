using ValeraAPI.DTOs;

namespace ValeraAPI.services
{
    public interface IValeraService
    {
        ValeraStateDTO GetState();

        ValeraStateDTO ExecuteAction(string Action);

        coid Reset();
    }
}