using Controllers;
using UnityEngine;

namespace Configs.Modules.Strategies
{
    public class HealthModuleStrategy: BaseModuleStrategy
    {
        public override ModuleType ModuleType => ModuleType.Standard;
        public override string Description => $"Increases Health by {Value}";

        [SerializeField] private float Value;
        
        public override void Setup(BattleStatsController battleStatsController)
        {
            base.Setup(battleStatsController);

            battleStatsController.ModifyMaxHealth(Value);
        }
    }
}