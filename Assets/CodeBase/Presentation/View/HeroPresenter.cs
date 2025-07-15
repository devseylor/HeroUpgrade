using UseCases;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;
using CodeBase.Domain.Models;

namespace Presentation
{
    public class HeroPresenter : IInitializable
    {
        private readonly HeroView _view;
        private readonly IUpgradeHeroUseCase _upgradeUseCase;
        private HeroModel _hero;

        public HeroPresenter(HeroView view, IUpgradeHeroUseCase upgradeUseCase)
        {
            this._view = view;
            this._upgradeUseCase = upgradeUseCase;
        }

        public void Initialize()
        {
            _ = InitializeAsync();
        }

        private async UniTask InitializeAsync()
        {
            _hero = new HeroModel();
            await UniTask.NextFrame();
            UpdateView();

            _view.UpgradeButton.clicked += async () =>
            {
                try
                {
                    await _upgradeUseCase.ExecuteAsync(_hero);
                    UpdateView();
                }
                catch (System.Exception ex)
                {
                    Debug.LogError(ex.Message);
                }
            };
        }

        private void UpdateView()
        {
            _view.LevelLabel.text = $"Level: {_hero.Level}";
            _view.GoldLabel.text = $"Gold: {_hero.Wallet.Gold}";
            _view.ExperienceLabel.text = $"Experience: {_hero.Wallet.Experience}";
        }
    }
}