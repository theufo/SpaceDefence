using System;
using Configs;
using Configs.Impl;
using Controllers;
using Controllers.Modules;
using UnityEngine;

namespace Utils
{
     public static class FactoryUtils
    {
        public static ModuleView ProduceModuleView(IModuleConfig config, Action<IModuleConfig> callback = null)
        {
            var instance = GameObject.Instantiate((config as ModuleConfig).Prefab);
            var view = instance.GetComponent<ModuleView>();
            view.Init(config, callback);

            return view;
        }

        public static IModuleController ProduceModuleController(ModuleView moduleView, BattleStatsController battleStatsController)
        {
            switch (moduleView.GetConfig())
            {
                case HealthModuleConfig : 
                case ShieldCooldownModuleConfig : 
                case ShieldModuleConfig : 
                case WeaponCooldownModuleConfig : 
                    return new BaseModuleController(moduleView, battleStatsController);
                case WeaponModuleConfig : 
                    return new WeaponModuleController(moduleView, battleStatsController); 
                default: return null;
            }
        }
    }
}
