using Configs;
using Managers;
using Managers.Hangar;
using UnityEngine;
using UnityEngine.UI;
using Screen = Assets.Scripts.Core.WindowSystem.Screen;

namespace UI.ModuleSelectorScreen
{
    public class ModuleSelectorScreen : Screen
    {
        [SerializeField] private ModuleInfoPanelComponent _moduleInfoPanelComponent;
        [SerializeField] private Button _startButton;

        public override void OnShow()
        {
            base.OnShow();
        
            _moduleInfoPanelComponent.gameObject.SetActive(false);
            ShipModulesManager.Instance.OnModuleHighlightedAction += OnModuleHighlighted;
        
            _startButton.onClick.AddListener(OnStartPressed);
        }

        public override void OnHide()
        {
            base.OnHide();
        
            ShipModulesManager.Instance.OnModuleHighlightedAction -= OnModuleHighlighted;
            _startButton.onClick.RemoveAllListeners();
        }

        private void OnStartPressed()
        {
            HangarManager.Instance.CompleteSetModules();
        }

        private void OnModuleHighlighted(IModuleConfig config)
        {
            if (config != null)
            {
                _moduleInfoPanelComponent.gameObject.SetActive(true);
                _moduleInfoPanelComponent.SetInfo(config);
            }
            else
            {
                _moduleInfoPanelComponent.gameObject.SetActive(false);
            }
        }
    }
}
