using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "SpaceDefence/Configs/ShipList")]
    public class ShipListConfig : ScriptableObject
    {
        public List<ShipConfig> ShipConfigs;
    }
}