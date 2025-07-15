using CodeBase.Domain.Models;
using Cysharp.Threading.Tasks;

namespace UseCases
{
    public interface IUpgradeHeroUseCase
    {
        UniTask ExecuteAsync(HeroModel hero);
    }
}
