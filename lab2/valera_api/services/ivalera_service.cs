using ValeraAPI.DTOs;

namespace ValeraAPI.services
{
    public interface IValeraService
    {
        Task<ValeraStateDTO> GetStateAsync(int valeraId = 1);

        Task<ValeraStateDTO> ExecuteActionAsync(string Action, int valeraId = 1);

        Task ResetAsync(int valeraId = 1);
    }
}