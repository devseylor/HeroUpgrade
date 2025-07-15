using Presentation;
using UseCases;
using VContainer;
using VContainer.Unity;
using MessagePipe;
using CodeBase.Domain.Messages;

namespace Infrastructure
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<HeroUpgradedMessage>(options);
            builder.RegisterMessageBroker<HeroUpgradeInputMessage>(options);

            builder.Register<UpgradeHeroUseCase>(Lifetime.Singleton)
                   .As<IUpgradeHeroUseCase>();

            builder.RegisterComponentInHierarchy<HeroView>();
            builder.RegisterComponentInHierarchy<UserInputController>();

            builder.RegisterEntryPoint<HeroPresenter>();
        }
    }
}
