using Controllers;
using UnityEngine;

namespace Configs.Impl
{
    [CreateAssetMenu(menuName = "SpaceDefence/Configs/HealthModuleConfig")]
    public class HealthModuleConfig : ModuleConfig
    {
        public override ModuleType ModuleType => ModuleType.Standard;
        public override string Description => $"Increases Health by {Value}";

        [SerializeField] private float Value;
        
        public override void Setup(BattleStatsController battleStatsController)
        {
            battleStatsController.ModifyMaxHealth(Value);
        }
    }
}