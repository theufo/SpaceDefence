using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "SpaceDefence/Configs/Ship")]
    public class ShipConfig : ScriptableObject
    {
        public GameObject Prefab;

        public int Health;
        public int Shield;
        public int WeaponSlots;
        public int ModuleSlots;
    }
}