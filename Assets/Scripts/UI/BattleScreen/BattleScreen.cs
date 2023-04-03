using Controllers;
using UnityEngine;
using Screen = Assets.Scripts.Core.WindowSystem.Screen;

namespace UI.BattleScreen
{
    public class BattleScreen : Screen
    {
        [SerializeField] private BattleStatsPanelComponent _playerStatsPanelComponent;
        [SerializeField] private BattleStatsPanelComponent _enemyStatsPanelComponent;

        [SerializeField] private WeaponButtonComponent _weaponButtonComponent1;
        [SerializeField] private WeaponButtonComponent _weaponButtonComponent2;

        public void SetInfo(BattleStatsController player, BattleStatsController enemy)
        {
            _playerStatsPanelComponent.SetInfo(player);
            _enemyStatsPanelComponent.SetInfo(enemy);

            var weaponModules = player.WeaponModules;

            _weaponButtonComponent1.SetInfo(weaponModules.Count > 0 ? weaponModules[0] : null);
            _weaponButtonComponent2.SetInfo(weaponModules.Count > 1 ? weaponModules[1] : null);
        }
    }
}