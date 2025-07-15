using Presentation;
using UseCases;
using VContainer;
using VContainer.Unity;
using MessagePipe;
using CodeBase.Domain.Messages;

namespace Infrastructure
{
    public class GameKernal : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UpgradeHeroUseCase>(Lifetime.Singleton)
                   .As<IUpgradeHeroUseCase>();

            builder.RegisterComponentInHierarchy<HeroView>();

            builder.RegisterEntryPoint<HeroPresenter>();
        }
    }
}
