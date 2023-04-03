using System.Collections.Generic;
using Configs;
using DefaultNamespace.Common;
using UnityEngine;

namespace Managers.Init
{
    public class ConfigsManager : Singleton<ConfigsManager>
    {
        [SerializeField] private ShipListConfig _shipListConfig;
        [SerializeField] private ModuleListConfig _moduleListConfig;

        private List<IModuleConfig> WeaponModules;
        private List<IModuleConfig> StandardModules;
        
        private void Awake()
        {
            base.Awake();

            WeaponModules = new List<IModuleConfig>();
            StandardModules = new List<IModuleConfig>();
            
            for (int i = 0; i < _moduleListConfig.ModuleConfigs.Count; i++)
            {
                var config = _moduleListConfig.ModuleConfigs[i];

                if (config.ModuleType == ModuleType.Standard)
                {
                    StandardModules.Add(config);
                }
                else if (config.ModuleType == ModuleType.Weapon)
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

        public IModuleConfig GetRandomWeaponModule()
        {
            return WeaponModules[Random.Range(0, WeaponModules.Count)];
        }
        
        public IModuleConfig GetRandomStandardModule()
        {
            return StandardModules[Random.Range(0, StandardModules.Count)];
        }
    }
}