using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "SpaceDefence/Configs/ModuleList")]
    public class ModuleListConfig : ScriptableObject
    {
        public List<ModuleConfig> ModuleConfigs;
    }
}