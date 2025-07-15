using CodeBase.Domain.Models;
using UseCases;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

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
            _hero = new HeroModel();
            UpdateView();

            _view.UpgradeButton.clicked += async () =>
            {
                await _upgradeUseCase.ExecuteAsync(_hero);
                UpdateView();
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