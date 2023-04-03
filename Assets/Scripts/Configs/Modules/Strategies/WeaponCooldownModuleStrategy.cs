using Controllers;
using UnityEngine;

namespace Configs.Modules.Strategies
{
    public class WeaponCooldownModuleStrategy : BaseModuleStrategy
    {
        public override ModuleType ModuleType => ModuleType.Standard;
        public override string Description => $"Reduces weapons cooldown by {Value * 100}%";

        [SerializeField] private float Value;

        public override void Setup(BattleStatsController battleStatsController)
        {
            base.Setup(battleStatsController);

            battleStatsController.ModifyWeaponCooldownSpeed(Value);
        }
    }
}