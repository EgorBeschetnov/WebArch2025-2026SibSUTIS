using Xunit;
using ValeraAPI.models;

namespace ValeraAPI.Tests
{
    public class ValeraTests
    {
        [Fact]
        public void GoToWork_Success_WhenсonditionsMet()
        {
            var valera = new Valera(mana: 30, fatigue: 5, cheerfulness: 0);
            var result = valera.GoToWork();
            Assert.True(result);
            Assert.Equal(0, valera.Mana);
            Assert.Equal(15, valera.Fatigue);
            Assert.Equal(200, valera.Money);
            Assert.Equal(1, valera.Cheerfulness);
        }

        [Fact]
        public void GoToWork_Fails_WhenManaTooHigh()
        {
            var valera = new Valera(mana: 51, fatigue: 9);
            var result = valera.GoToWork();
            Assert.False(result);
        }

        [Fact]
        public void GoToWork_Fails_WhenFatigueTooHigh()
        {
            var valera = new Valera(mana: 49, fatigue: 10);
            var result = valera.GoToWork();
            Assert.False(result);
        }

        [Fact]
        public void GoToWork_Fails_WhenManaAndFatigueTooHigh()
        {
            var valera = new Valera(mana: 51, fatigue: 10);
            var result = valera.GoToWork();
            Assert.False(result);
        }

        [Fact]
        public void ContemplateNature_IncreasesCheerfulness()
        {
            var valera = new Valera();
            valera.ContemplateNature();
            Assert.Equal(1, valera.Cheerfulness);
            Assert.Equal(0, valera.Mana);
            Assert.Equal(10, valera.Fatigue);
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
            Assert.Equal(60, valera.Money);
        }

        [Fact]
        public void Properties_StaysWithBounds()
        {
            var valera = new Valera();
            for (int i = 0; i < 10; i++)
            {
                valera.DrinkWithMarginals();
            }
            Assert.InRange(valera.Health, 0, 100);
            Assert.InRange(valera.Mana, 0, 100);
            Assert.InRange(valera.Cheerfulness, -10, 10);
            Assert.InRange(valera.Fatigue, 0, 100);
        }
    }
}