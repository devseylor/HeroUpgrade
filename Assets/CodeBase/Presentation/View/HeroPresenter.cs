using CodeBase.Domain.Models;
using UseCases;
using Cysharp.Threading.Tasks;
using R3;
using CodeBase.Domain.Messages;
using MessagePipe;
using UnityEngine;
using VContainer.Unity;

namespace Presentation
{
    public class HeroPresenter : IInitializable
    {
        private readonly HeroView _view;
        private readonly IUpgradeHeroUseCase _upgradeUseCase;
        private readonly IAsyncSubscriber<HeroUpgradedMessage> _upgradedSubscriber;
        private readonly IAsyncSubscriber<HeroUpgradeInputMessage> _inputSubscriber;
        private HeroModel _hero;

        public HeroPresenter(
            HeroView view,
            IUpgradeHeroUseCase upgradeUseCase,
            IAsyncSubscriber<HeroUpgradedMessage> upgradedSubscriber,
            IAsyncSubscriber<HeroUpgradeInputMessage> inputSubscriber)
        {
            _view = view;
            _upgradeUseCase = upgradeUseCase;
            _upgradedSubscriber = upgradedSubscriber;
            _inputSubscriber = inputSubscriber;
        }

        public void Initialize()
        {
            _hero = new HeroModel(1);
            UpdateView();

            _view.UpgradeButton.clicked += async () =>
            {
                await ExecuteUpgradeAsync();
            };

            _upgradedSubscriber.Subscribe(async (_, ct) =>
            {
                await UniTask.SwitchToMainThread(ct);
                UpdateView();
            });

            _inputSubscriber.Subscribe(async (_, ct) =>
            {
                await ExecuteUpgradeAsync();
            });
        }

        private async UniTask ExecuteUpgradeAsync()
        {
            try
            {
                await _upgradeUseCase.ExecuteAsync(_hero);
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }

        private void UpdateView()
        {
            _view.LevelLabel.text = $"Level: {_hero.Level}";
            _view.GoldLabel.text = $"Gold: {_hero.Wallet.Gold}";
            _view.ExperienceLabel.text = $"Experience: {_hero.Wallet.Experience}";
        }
    }
}