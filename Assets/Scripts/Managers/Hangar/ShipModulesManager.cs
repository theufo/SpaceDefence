using System;
using System.Collections.Generic;
using Configs;
using DefaultNamespace.Common;
using DefaultNamespace.Views;
using UnityEngine;

namespace Managers.Hangar
{
    public class ShipModulesManager : Singleton<ShipModulesManager>
    {
        [SerializeField] private ItemsStackView _itemsStackView;
        
        public Action<ModuleConfig> OnModuleHighlightedAction;

        private void Awake()
        {
            base.Awake();
            _itemsStackView.gameObject.SetActive(false);
        }

        public void Init(List<ModuleConfig> config)
        {
            for (int i = 0; i < config.Count; i++)
            {
                _itemsStackView.AddToStack(config[i], OnModuleHighlighted);
            }
        }

        public void InitState()
        {
            _itemsStackView.gameObject.SetActive(true);
        }
        
        private void OnModuleHighlighted(ModuleConfig config)
        {
            OnModuleHighlightedAction?.Invoke(config);
        }
    }
}
