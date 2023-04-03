using Controllers;
using UnityEngine;

namespace Configs.Impl
{
    [CreateAssetMenu(menuName = "SpaceDefence/Configs/ShieldModuleConfig")]
    public class ShieldModuleConfig : ModuleConfig
    {
        public override ModuleType ModuleType => ModuleType.Standard;
        public override string Description => $"Increases shield by {Value}";

        [SerializeField] private float Value;

        public override void Setup(BattleStatsController battleStatsController)
        {
            battleStatsController.ModifyMaxShield(Value);
        }
    }
}