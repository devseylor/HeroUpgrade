using CodeBase.Domain.Messages;
using CodeBase.Domain.Models;
using Cysharp.Threading.Tasks;
using MessagePipe;

namespace UseCases
{
    public class UpgradeHeroUseCase : IUpgradeHeroUseCase
    {
        private const int GoldCost = 100;
        private const int ExpCost = 50;
        private readonly IAsyncPublisher<HeroUpgradedMessage> _upgradedPublisher;

        public UpgradeHeroUseCase(IAsyncPublisher<HeroUpgradedMessage> upgradedPublisher)
        {
            _upgradedPublisher = upgradedPublisher;
        }

        public async UniTask ExecuteAsync(HeroModel hero)
        {
            hero.Wallet.SpendGold(GoldCost);
            hero.Wallet.SpendExperience(ExpCost);
            hero.UpgradeHero();
            await _upgradedPublisher.PublishAsync(new HeroUpgradedMessage(), default);
        }
    }
}