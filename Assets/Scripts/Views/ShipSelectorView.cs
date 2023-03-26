using System;
using Configs;
using DefaultNamespace.Managers;
using UnityEngine;

namespace DefaultNamespace.Views
{
    public class ShipSelectorView : MonoBehaviour
    {
        [SerializeField] private GameObject _selector;

        private Action<ShipConfig> _onShipHighlightedCallback;
        
        private Collider _collider;

        private ShipView _shipView;
        private bool _enabled;

        private void Awake()
        {
            _enabled = true;
            _collider = GetComponent<BoxCollider>();
            _selector.SetActive(false);
        }

        public void Init(ShipConfig config, Action<ShipConfig> callback)
        {
            _onShipHighlightedCallback = callback;
            
            var shipInstance = Instantiate(config.Prefab, transform);
            _collider.enabled = true;
            _enabled = true;
            _shipView = shipInstance.GetComponent<ShipView>();
            _shipView.Init(config);
        }
            
        private void OnMouseDown()
        {
            if (!_enabled) return;
            
            _selector.SetActive(false);
            _collider.enabled = false;
            _enabled = false;
            HangarManager.Instance.CompleteSelectShip(_shipView);
        }

        private void OnMouseOver()
        {
            if (!_enabled) return;

            _onShipHighlightedCallback?.Invoke(_shipView.ShipConfig);
            _selector.SetActive(true);
            _shipView.HighlightAllSlots(true);
        }

        private void OnMouseExit()
        {
            if (!_enabled) return;

            _onShipHighlightedCallback?.Invoke(null);
            _selector.SetActive(false);
            _shipView.HighlightAllSlots(false);
        }

        private void OnDestroy()
        {
            _onShipHighlightedCallback = null;
        }
    }
}