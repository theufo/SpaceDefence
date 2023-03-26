using System.Collections.Generic;
using Configs;
using DefaultNamespace.Common;
using UnityEngine;

namespace DefaultNamespace.Managers
{
    public class ConfigsManager : Singleton<ConfigsManager>
    {
        [SerializeField] private ShipListConfig _shipListConfig;
        [SerializeField] private ModuleListConfig _moduleListConfig;

        private List<ModuleConfig> WeaponModules;
        private List<ModuleConfig> StandardModules;
        
        private void Awake()
        {
            base.Awake();

            WeaponModules = new List<ModuleConfig>();
            StandardModules = new List<ModuleConfig>();
            
            for (int i = 0; i < _moduleListConfig.ModuleConfigs.Count; i++)
            {
                var config = _moduleListConfig.ModuleConfigs[i];

                if (config.Strategy.ModuleType == ModuleType.Standard)
                {
                    StandardModules.Add(config);
                }
                else if (config.Strategy.ModuleType == ModuleType.Weapon)
                {
                    WeaponModules.Add(config);
                }
            }
        }

        public List<ShipConfig> GetShipsConfig()
        {
            return _shipListConfig.ShipConfigs;
        }
        
        public List<ModuleConfig> GetModulesConfig()
        {
            return _moduleListConfig.ModuleConfigs;
        }

        public ModuleConfig GetRandomWeaponModule()
        {
            return WeaponModules[Random.Range(0, WeaponModules.Count)];
        }
        
        public ModuleConfig GetRandomStandardModule()
        {
            return StandardModules[Random.Range(0, StandardModules.Count)];
        }
    }
}