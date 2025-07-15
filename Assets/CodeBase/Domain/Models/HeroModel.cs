namespace CodeBase.Domain.Models
{
    public class HeroModel
    {
        public int Level { get; private set; }
        public WalletModel Wallet { get; private set; }

        public HeroModel(int level)
            : this(level, new WalletModel(initialGold: 0, initialExperience: 0))
        {
        }

        public HeroModel(int level, WalletModel wallet)
        {
            Level = level;
            Wallet = wallet;
        }

        public void UpgradeHero()
        {
            Level++;
        }
    }
}
