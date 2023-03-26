using System;
using Configs;
using UnityEngine;

namespace DefaultNamespace.Utils
{
     public static class FactoryUtils
    {
        public static ModuleView ProduceModuleView(ModuleConfig config, Action<ModuleConfig> callback = null)
        {
            var instance = GameObject.Instantiate(config.Prefab);
            var view = instance.GetComponent<ModuleView>();
            view.Init(config, callback);

            return view;
        }
    }
}