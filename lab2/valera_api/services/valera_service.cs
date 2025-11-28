using ValeraAPI.models;
using ValeraAPI.DTOs;
using ValeraAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ValeraAPI.services
{
    public class ValeraService : IValeraService
    {
        private readonly AppDbContext _valera;

        public ValeraService(AppDbContext valera)
        {
            _valera = valera;
        }

        public async Task<ValeraStateDTO> GetStateAsync(int valeraId = 1)
        {
            var valera = await GetOrCreateValeraAsync(valeraId);
            return MapToDTO(valera);
            
        }

        public async Task<ValeraStateDTO> ExecuteActionAsync(string Action, int valeraId = 1)
        {
            var valera = await GetOrCreateValeraAsync(valeraId);
            bool success = true;

            switch (Action.ToLower())
            {
                case "work":
                    success = valera.GoToWork();
                    break;

                case "nature":
                    success = valera.ContemplateNature();
                    break;

                case "tv":
                    success = valera.DrinkWineAndWatchTV();
                    break;

                case "bar":
                    success = valera.GoToBar();
                    break;

                case "marginals":
                    success = valera.DrinkWithMarginals();
                    break;

                case "sing":
                    success = valera.SingInSubway();
                    break;

                case "sleep":
                    success = valera.Sleep();
                    break;

                default:
                    throw new ArgumentException($"Unknown action: {Action}");

            
            }

            if (!success)
            {
                throw new InvalidOperationException($"Action '{Action}' cannot be performed due to constraints"); 
            }

            _valera.ValeraS.Update(valera);
            await _valera.SaveChangesAsync();

            return MapToData(valera);
        }

        public async Task ResetAsync(int valeraId = 1)
        {
            var valera = await GetOrCreateValeraAsync();

            var newValera = new Valera();
            Valera.Health = newValera.Health;
            Valera.Mana = newValera.Mana;
            Valera.Cheerfulness = newValera.Cheerfulness;
            Valera.Fatigue = newValera.Fatigue;
            Valera.Money = newValera.Money;

            _valera.ValeraS.Update(valera);
            await _valera.SaveChangesAsync();
        }

        private async Task<Valera> GetOrCreateValeraAsync(int valeraId)
        {
            var valera = await _valera.ValeraS.FindAsync(valeraId);
            if (valera == null)
            {
                valera = new Valera();
                valera.Id = valeraId;
                _valera.ValeraS.Add(valera);
                await _valera.SaveChangesAsync();
            }
            return valera;
        }

        private ValeraStateDTO MapToDTO(Valera valera)
        {
            return new ValeraStateDTO
            {
                Health = valera.Health,
                Mana = valera.Mana,
                Cheerfulness = valera.Cheerfulness,
                Fatigue = valera.Fatigue,
                Money = valera.Money,
            };
        }
    }
}