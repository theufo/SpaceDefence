using Configs;
using DefaultNamespace.Managers;
using DefaultNamespace.UI;
using UnityEngine;
using UnityEngine.UI;
using Screen = Assets.Scripts.Core.WindowSystem.Screen;

public class ModuleSelectorScreen : Screen
{
    [SerializeField] private ModuleInfoPanelComponent _moduleInfoPanelComponent;
    [SerializeField] private Button _startButton;

    public override void OnShow()
    {
        base.OnShow();
        
        _moduleInfoPanelComponent.gameObject.SetActive(false);
        ShipModulesManager.Instance.OnModuleHighlightedAction += OnShipHighlighted;
        
        _startButton.onClick.AddListener(OnStartPressed);
    }

    public override void OnHide()
    {
        base.OnHide();
        
        ShipModulesManager.Instance.OnModuleHighlightedAction -= OnShipHighlighted;
        _startButton.onClick.RemoveAllListeners();
    }

    private void OnStartPressed()
    {
        HangarManager.Instance.CompleteSetModules();
    }

    private void OnShipHighlighted(ModuleConfig config)
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
