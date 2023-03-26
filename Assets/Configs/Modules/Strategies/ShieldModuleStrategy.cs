using DefaultNamespace.Controllers;
using UnityEngine;

namespace Configs.Modules.Strategies
{
    public class ShieldModuleStrategy : BaseModuleStrategy
    {
        public override ModuleType ModuleType => ModuleType.Standard;
        public override string Description => $"Increases shield by {Value}";

        [SerializeField] private float Value;

        public override void Setup(BattleStatsController battleStatsController)
        {
            base.Setup(battleStatsController);

            battleStatsController.ModifyMaxShield(Value);
        }
    }
}