namespace CodeBase.Domain.Models
{
    public class HeroModel
    {
        public int Level { get; private set; }

        public HeroModel(int level)
        {
            Level = level;
        }

        public void UpgradeHero()
        {
            Level++;
        }
    }
}
