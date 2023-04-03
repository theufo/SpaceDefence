using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace Controllers.Ship
{
    public class ShipSlotsController : MonoBehaviour
    {
        [SerializeField] private SlotController[] _standardSlots;
        [SerializeField] private SlotController[] _weaponSlots;
    
        public void HighlightSlots(bool highlight, ModuleType type)
        {
            var list = GetSlotsByType(type);

            for (int i = 0; i < list.Length; i++)
            {
                list[i].HighlightSlot(highlight);
            }
        }
    
        public void EnableSlots(bool enable, ModuleType type)
        {
            var list = GetSlotsByType(type);

            for (int i = 0; i < list.Length; i++)
            {
                list[i].EnableSlot(enable);
            }
        }

        public SlotController[] GetWeaponSlots()
        {
            return _weaponSlots;
        }

        public SlotController[] GetStandardSlots()
        {
            return _standardSlots;
        }

        public List<ModuleView> GetStandardModuleViews()
        {
            return InitModulesConfigs(_standardSlots);
        }
    
        public List<ModuleView> GetWeaponModuleViews()
        {
            return InitModulesConfigs(_weaponSlots);
        }

        private SlotController[] GetSlotsByType(ModuleType type)
        {
            if (type == ModuleType.Standard)
            {
                return _standardSlots;
            }
            else if (type == ModuleType.Weapon)
            {
                return _weaponSlots;
            
            }
            else
            {
                return null;
            }
        }

        private List<ModuleView> InitModulesConfigs(SlotController[] slotControllers)
        {
            var moduleViews = new List<ModuleView>();

            for (int i = 0; i < slotControllers.Length; i++)
            {
                if (slotControllers[i].Empty) continue;

                var slot = slotControllers[i];
                var moduleView = slot.ModuleView;
                if (moduleView != null)
                {
                    moduleViews.Add(moduleView);
                }
            }

            return moduleViews;
        }
    }
}
