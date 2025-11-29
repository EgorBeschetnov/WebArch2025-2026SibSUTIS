namespace ValeraAPI.models
{
	public class Valera
	{
		public int Id { get; set; }
		public int Health { get; set; }
		public int Mana { get; set; }
		public int Cheerfulness { get; set; }
		public int Fatigue { get; set; }
		public int Money { get; set; }

		public Valera()
        {
            Health = 100;
			Mana = 0;
			Cheerfulness = 0;
			Fatigue = 0;
			Money = 100;
        }

		public Valera(int health = 100, int mana = 0, int cheerfulness = 0, int fatigue = 0, int money = 100)
		{
			Health = ValidateRange(health, 0, 100);
			Mana = ValidateRange(mana, 0, 100);
			Cheerfulness = ValidateRange(cheerfulness, -10, 10);
			Fatigue = ValidateRange(fatigue, 0, 100);
			Money = ValidateRange(money, 0, 1000);
		}

		public bool GoToWork()
		{
			if (Mana >= 50 || Fatigue >= 10)
				return false;

			Cheerfulness = ValidateRange(Cheerfulness + 1, -10, 10);
			Mana = ValidateRange(Mana -30, 0, 100);
			Money += 100;
			Fatigue = ValidateRange(Fatigue +10, 0, 100);
			return true;
		}

		public void ContemplateNature()
		{
			Cheerfulness = ValidateRange(Cheerfulness + 1, -10, 10);
			Mana = ValidateRange(Mana - 10, 0, 100);
			Fatigue = ValidateRange( Fatigue + 10, 0, 100);
		}

		public void DrinkWineAndWatchTV()
		{
			Cheerfulness = ValidateRange(Cheerfulness -1, -10, 10);
			Mana = ValidateRange(Mana + 30, 0, 100);
			Fatigue = ValidateRange(Fatigue + 10, 0, 100);
			Health = ValidateRange(Health - 5, 0, 100);
			Money -= 20;
		}

		public void GoToBar()
		{
			Cheerfulness = ValidateRange(Cheerfulness + 1, -10, 10);
			Mana = ValidateRange(Mana + 60, 0, 100);
			Fatigue = ValidateRange(Fatigue + 40, 0, 100);
			Health = ValidateRange(Health -10, 0, 100);
			Money -= 100;
		}

		public void DrinkWithMarginals()
		{
			Cheerfulness = ValidateRange(Cheerfulness + 5, -10, 10);
			Health = ValidateRange(Health - 80, 0, 100);
			Mana = ValidateRange(Mana + 90, 0, 100);
			Fatigue = ValidateRange(Fatigue + 80, 0, 100);
			Money -= 150;
		}

		public void SingInSubway()
		{
			Cheerfulness = ValidateRange(Cheerfulness + 1, -10, 10);
			Mana = ValidateRange(Mana + 10, 0, 100);
			Fatigue = ValidateRange(Fatigue + 20, 0, 100);

			Money += 10;
			if (Mana > 40 && Mana < 70)
			{
				Money += 50;
			}
		}

		public void Sleep()
		{
			if (Mana < 30)
			{
				Health = ValidateRange(Health + 90, 0, 100);
			}

			if (Mana > 70)
			{
				Cheerfulness = ValidateRange(Cheerfulness - 3, -10, 10);
			}

			Mana = ValidateRange(Mana - 50, 0, 100);
			Fatigue = ValidateRange(Fatigue - 70, 0, 100);
		
		}

		private int ValidateRange(int value, int min, int max)
		{
			return Math.Min(Math.Max(value, min), max);
		}
		
	}
}
