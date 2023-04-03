using Controllers;
using UnityEngine;

namespace Configs.Impl
{
    [CreateAssetMenu(menuName = "SpaceDefence/Configs/WeaponCooldownModuleConfig")]
    public class WeaponCooldownModuleConfig : ModuleConfig
    {
        public override ModuleType ModuleType => ModuleType.Standard;
        public override string Description => $"Reduces weapons cooldown by {Value * 100}%";

        [SerializeField] private float Value;

        public override void Setup(BattleStatsController battleStatsController)
        {
            battleStatsController.ModifyWeaponCooldownSpeed(Value);
        }
    }
}