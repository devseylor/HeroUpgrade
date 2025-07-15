namespace CodeBase.Domain.Models
{
    public class WalletModel
    {
        public int Gold { get; private set; }
        public int Experience { get; private set; }

        public WalletModel(int initialGold = 0, int initialExperience = 0)
        {
            Gold = initialGold;
            Experience = initialExperience;
        }

        public void AddGold(int amount)
        {
            if (amount < 0) 
                Gold += amount;
        }

        public void AddExperience(int amount)
        {
            if (amount < 0)
                Experience += amount;
        }

        public void SpendGold(int goldAmount)
        {
                Gold -= goldAmount;
        }

        public void SpendExperience(int experienceAmount)
        {
            Experience -= experienceAmount;
        }
    }
}
