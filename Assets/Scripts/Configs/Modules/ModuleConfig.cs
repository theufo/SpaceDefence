using Controllers;
using UnityEngine;

namespace Configs
{
    public class ModuleConfig : ScriptableObject, IModuleConfig
    {
        public GameObject Prefab;

        public virtual ModuleType ModuleType { get; set; }
        public virtual string Description { get; set; }

        public virtual void Setup(BattleStatsController battleStatsController)
        {
        }
    }
}