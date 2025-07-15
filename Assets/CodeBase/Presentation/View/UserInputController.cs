using UnityEngine;
using UnityEngine.InputSystem;
using MessagePipe;
using CodeBase.Domain.Messages;
using CodeBase.Domain.Messages;
using VContainer;

namespace Presentation
{
    [RequireComponent(typeof(PlayerInput))]
    public class UserInputController : MonoBehaviour
    {
        private InputAction _upgradeAction;
        private IAsyncPublisher<HeroUpgradeInputMessage> _publisher;

        [Inject]
        public void Construct(IAsyncPublisher<HeroUpgradeInputMessage> publisher)
        {
            _publisher = publisher;
        }

        void Awake()
        {
            var playerInput = GetComponent<PlayerInput>();
            _upgradeAction = playerInput.actions["Upgrade"]; 
        }

        void OnEnable()
        {
            _upgradeAction.performed += OnUpgrade;
        }

        void OnDisable()
        {
            _upgradeAction.performed -= OnUpgrade;
        }

        private void OnUpgrade(InputAction.CallbackContext ctx)
        {
            _ = _publisher.PublishAsync(new HeroUpgradeInputMessage(), default);
        }
    }
}