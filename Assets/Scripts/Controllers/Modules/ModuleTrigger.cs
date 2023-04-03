using System;
using Configs;
using Controllers.Ship;
using UnityEngine;

namespace Controllers.Modules
{
    public class ModuleTrigger : MonoBehaviour
    {
        public Action<SlotController> OnModuleSlotTouch;

        private Collider _currentSlotController;

        private ModuleType _moduleType;
        
        public void Init(ModuleType moduleType)
        {
            _moduleType = moduleType;
        }

        public void Reset()
        {
            _currentSlotController = null;
        }

        private void OnTriggerEnter(Collider other)
        {
            var controller = other.gameObject.GetComponent<SlotController>();

            if (controller != null)
            {
                
            }
            
            if (controller != null && 
                _currentSlotController != other &&
                controller.ModuleType == _moduleType &&
                controller.Empty
                )
            {
                _currentSlotController = other;
                OnModuleSlotTouch?.Invoke(other.gameObject.GetComponent<SlotController>());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<SlotController>() != null && _currentSlotController == other)
            {
                _currentSlotController.gameObject.GetComponent<SlotController>().SetModule(null);
                _currentSlotController = null;
                OnModuleSlotTouch?.Invoke(null);
            }
        }
    }
}