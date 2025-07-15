using CodeBase.Domain.Messages;
using CodeBase.Domain.Models;
using Cysharp.Threading.Tasks;
using MessagePipe;

namespace UseCases
{
    public class UpgradeHeroUseCase : IUpgradeHeroUseCase
    {
        public UniTask ExecuteAsync(HeroModel hero)
        {
            hero.UpgradeHero();
            return UniTask.CompletedTask;
        }
    }
}