using Configs;
using Managers;
using Managers.Hangar;
using UnityEngine;
using Screen = Assets.Scripts.Core.WindowSystem.Screen;

namespace UI.ShipSelectorScreen
{
    public class ShipSelectorScreen : Screen
    {
        [SerializeField] private ShipInfoPanelComponent _shipInfoPanelComponent;

        public override void OnShow()
        {
            base.OnShow();
        
            _shipInfoPanelComponent.gameObject.SetActive(false);
            ShipSelectionManager.Instance.OnShipHighlightedAction += OnShipHighlighted;
        }

        public override void OnHide()
        {
            base.OnHide();
            ShipSelectionManager.Instance.OnShipHighlightedAction -= OnShipHighlighted;
        }

        private void OnShipHighlighted(ShipConfig config)
        {
            if (config != null)
            {
                _shipInfoPanelComponent.gameObject.SetActive(true);
                _shipInfoPanelComponent.SetInfo(config);
            }
            else
            {
                _shipInfoPanelComponent.gameObject.SetActive(false);
            }
        }
    }
}
