using Controllers;
using UnityEngine;

namespace Configs.Modules.Strategies
{
    public class ShieldCooldownModuleStrategy : BaseModuleStrategy
    {
        public override ModuleType ModuleType => ModuleType.Standard;
        public override string Description => $"Increases shield recharge speed by {Value * 100}%";

        [SerializeField] private float Value;

        public override void Setup(BattleStatsController battleStatsController)
        {
            base.Setup(battleStatsController);

            battleStatsController.ModifyShieldCooldownSpeed(Value);
        }
    }
}