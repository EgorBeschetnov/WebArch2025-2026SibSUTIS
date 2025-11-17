using ValeraAPI.Models;
using ValeraAPI.DTOs;

namespace ValeraAPI.services
{
    public interface IValeraService
    {
        ValeraStateDTO GetState();
        ValeraStateDTO ExecuteAction(string Action);
        void Reset();
    }

    public class ValeraService : IValeraService
    {
        private ValeraService _valera;

        public ValeraService()
        {
            _valera = new Valera();
        }
        
        public ValeraStateDTO GetState()
        {
            return new ValeraStateDTO
            {
                Health = _valera.Health,
                Mana = _valera.Mana,
                Cheerfulness = _valera.Cheerfulness,
                Fatigue = _valera.Fatigue,
                Money = _valera.Money
            };
        }
        
        public ValeraStateDTO ExecuteAction(string Action)
        {
            bool success = true;

            switch (Action.ToLower())
            {
                case "work":
                    success = _valera.GoToWork();
                    break;
                case "nature":
                    success = _valera.ContemplateNature();
                    break;
                case "tv":
                    success = _valera.DrinkWineAndWatchTV();
                    break;
                case "bar":
                    success = _valera.GoToBar();
                    break;
                case "marginals":
                    success = _valera.DrinkWithMarginals();
                    break;
                case "sing":
                    success = _valera.SingInSubway();
                    break;
                case "sleep":
                    success = _valera.Sleep();
                    break;
                default:
                    throw new ArgumentException($"Unknown action: {Action}");
            }

            if (!success)
            {
                throw new InvalidOperationException($"Action '{Action}' cannot be performed due to constraints");
            }

            return GetState();
        }

        public void Reset()
        {
            _valera = new Valera();
        }
    }
}