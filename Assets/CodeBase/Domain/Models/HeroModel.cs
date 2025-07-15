namespace CodeBase.Domain.Models
{
    public class HeroModel
    {
        public int Level { get; private set; }
        public WalletModel Wallet { get; private set; }

        public HeroModel()
        {
            Level = 1;
            Wallet = new WalletModel();
        }


        public void UpgradeHero()
        {
            const int goldCost = 100;
            const int expCost = 50;
            Wallet.SpendExperience(expCost);
            Wallet.SpendGold(goldCost);
            Level++;
        }
    }
}
