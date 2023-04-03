using Assets.Scripts.Core.WindowSystem;
using Controllers;
using TMPro;
using UnityEngine;

namespace UI.BattleScreen
{
    public class BattleStatsPanelComponent : ScreenComponent
    {
        [SerializeField] private TMP_Text _health;
        [SerializeField] private TMP_Text _shield;

        private BattleStatsController _controller;
        
        public void SetInfo(BattleStatsController controller)
        {
            _controller = controller;
            
            _health.SetText($"Health: {_controller.Health}/{_controller.HealthMax}");
            _shield.SetText($"Shield: {_controller.Shield}/{_controller.ShieldMax}");

            _controller.OnHealthChanged += OnHealthChanged;
            _controller.OnShieldChanged += OnShieldChanged;
        }

        private void OnShieldChanged(float value)
        {
            _shield.SetText($"Shield: {Mathf.Clamp(value, 0, _controller.ShieldMax):n2}/{_controller.ShieldMax}");
        }

        private void OnHealthChanged(float value)
        {
            _health.SetText($"Health: {Mathf.Clamp(value, 0, _controller.HealthMax):n2}/{_controller.HealthMax}");
        }

    }
}