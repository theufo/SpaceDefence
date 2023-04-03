using System;
using System.Collections.Generic;
using Configs;
using DefaultNamespace.Common;
using DefaultNamespace.Views;
using UnityEngine;

namespace Managers.Hangar
{
    public class ShipSelectionManager : Singleton<ShipSelectionManager>
    {
        [SerializeField] private Transform[] _shipPlaces;
        [SerializeField] private GameObject _shipSelectorViewPrefab;

        public Action<ShipConfig> OnShipHighlightedAction;

        private List<ShipSelectorView> _selectorViews;

        public void Init(List<ShipConfig> shipConfigs)
        {
            _selectorViews = new List<ShipSelectorView>();
            
            for (int i = 0; i < shipConfigs.Count; i++)
            {
                var selectorInstance = Instantiate(_shipSelectorViewPrefab, _shipPlaces[i]);
                var selectorView = selectorInstance.GetComponent<ShipSelectorView>();

                selectorView.Init(shipConfigs[i], OnShipHighlighted);
                
                _selectorViews.Add(selectorView);
            }
        }

        public void DeInit()
        {
            for (int i = 0; i < _selectorViews.Count; i++)
            {
                _selectorViews[i].enabled = false;
            }
        }

        private void OnShipHighlighted(ShipConfig config)
        {
            OnShipHighlightedAction?.Invoke(config);
        }
    }
}