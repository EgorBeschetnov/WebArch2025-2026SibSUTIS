using Xunit;
using ValeraAPI.models;

namespace ValeraAPI.Tests
{
    public class ValeraTests
    {
        [Fact]
        public void GoToWork_Success_WhenonditionsMet()
        {
            var valera = new ValeraAPI(mana: 30, fatique: 5);
            var result = valera.GoToWork();
            Assert.True(result);
            Assert.Equal(0, valera.Mana);
            Assert.Equal(75, valera.Fatigue);
            Assert.Equal(100, valera.Money);
            Assert.Equal(-5, valera.Cheerfulness);
        }

        [Fact]
        public void GoToWork_Fails_WhenManaTooHigh()
        {
            var valera = new Valera();
            var result = valera.GoToWork();
            Assert.False(result);
        }

        [Fact]
        public void ContemplateNature_IncreasesCheerfulness()
        {
            var valera = new Valera();
            valera.ContemplateNature();
            Assert.Equal(1, valera.Cheerfulness);
            Assert.Equal(90, valera.Mana);
            Assert.Equeal(10, valera.Fatigue);
        }

        [Fact]
        public void DrinkWineAndWatchTV()
        {
            var valera = new Valera(money: 100);
            valera.DrinkWineAndWatchTV();
            Assert.Equal(95, valera.Health);
            Assert.Equal(30, valera.Mana);
            Assert.Equal(-1, valera.Cheerfulness);
            Assert.Equal(10, valera.Fatigue);
            Assert.Equal(80, valera.Money);
        }

        [Fact]
        public void Sleep_IncreasesHealth_WhenManaLow()
        {
            var valera = new Valera(health: 50, mana: 20);
            valera.Sleep();
            Assert.Equal(100, valera.Health);
            Assert.Equal(0, valera.Mana);
        }

        [Fact]
        public void SingInSubway_ExtraMoney_WhenManaInRange()
        {
            var valera = new Valera(mana: 50, money: 0);
            valera.SingInSubway();
            Assery.Equal(60, valera.Money);
        }

        [Fact]
        public void Properties_StaysWithBounds()
        {
            var valera = new Valera();
            for (int i = 0; i < 10; i++)
            {
                valera.DrinkingWithMarginals();
            }
            Assert.InRange(valera.Health, 0, 100);
            Assert.InRange(valera.Mana, 0, 100);
            Assert.InRange(valera.Cheerfulness, -10, 10);
            Assert.InRange(valera.Farigue, 0, 100);
        }
    }
}