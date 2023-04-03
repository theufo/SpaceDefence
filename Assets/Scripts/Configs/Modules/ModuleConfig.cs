using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "SpaceDefence/Configs/Module")]
    public class ModuleConfig : ScriptableObject
    {
        public GameObject Prefab;
        public BaseModuleStrategy Strategy;
    }
}