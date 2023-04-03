using Controllers;
using UnityEngine;

namespace Configs
{
    public class BaseModuleStrategy : MonoBehaviour, IModuleStrategy
    {
        public virtual ModuleType ModuleType { get; set; }
        public virtual string Description { get; set; }

        protected BattleStatsController _battleStatsController;

        public virtual void Setup(BattleStatsController battleStatsController)
        {
            _battleStatsController = battleStatsController;
        }

        public virtual void StartModule()
        {
        }

        public virtual void Activate()
        {
        }
    }
}