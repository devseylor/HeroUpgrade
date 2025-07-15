using UnityEngine;
using UnityEngine.UIElements;

namespace Presentation
{
    [RequireComponent(typeof(UIDocument))]
    public class HeroView : MonoBehaviour
    {
        public Button UpgradeButton { get; private set; }
        public Label LevelLabel { get; private set; }
        public Label GoldLabel { get; private set; }
        public Label ExperienceLabel { get; private set; }

        private VisualElement _root;

        void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            LevelLabel = _root.Q<Label>("LevelLabel");
            GoldLabel = _root.Q<Label>("GoldLabel");
            ExperienceLabel = _root.Q<Label>("ExperienceLabel");
            UpgradeButton = _root.Q<Button>("UpgradeButton");
        }
    }
}