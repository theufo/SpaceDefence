using Assets.Scripts.Core.WindowSystem;
using Configs;
using TMPro;
using UnityEngine;

namespace UI.ModuleSelectorScreen
{
    public class ModuleInfoPanelComponent : ScreenComponent
    {
        [SerializeField] private TMP_Text _typeText;
        [SerializeField] private TMP_Text _descriptionText;
        
        public void SetInfo(ModuleConfig config)
        {
            _typeText.text = config.Strategy.ModuleType.ToString();
            _descriptionText.text = config.Strategy.Description.ToString();
        }
    }
}