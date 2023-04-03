using Controllers;
using UnityEngine;

namespace Configs.Impl
{
    [CreateAssetMenu(menuName = "SpaceDefence/Configs/ShieldCooldownModuleConfig")]
    public class ShieldCooldownModuleConfig : ModuleConfig
    {
        public override ModuleType ModuleType => ModuleType.Standard;
        public override string Description => $"Increases shield recharge speed by {Value * 100}%";

        [SerializeField] private float Value;

        public override void Setup(BattleStatsController battleStatsController)
        {
            battleStatsController.ModifyShieldCooldownSpeed(Value);
        }
    }
}