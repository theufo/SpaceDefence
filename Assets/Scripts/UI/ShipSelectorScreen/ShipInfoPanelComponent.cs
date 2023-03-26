using Assets.Scripts.Core.WindowSystem;
using Configs;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class ShipInfoPanelComponent : ScreenComponent
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _shieldText;
        [SerializeField] private TMP_Text _weaponSlotsText;
        [SerializeField] private TMP_Text _moduleSlotsText;
        
        public void SetInfo(ShipConfig config)
        {
            _healthText.text = config.Health.ToString();
            _shieldText.text = config.Shield.ToString();
            _weaponSlotsText.text = config.WeaponSlots.ToString();
            _moduleSlotsText.text = config.ModuleSlots.ToString();
        }
    }
}