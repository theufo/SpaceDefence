using System.Collections.Generic;
using Configs;
using UnityEngine;

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

    public List<IModuleStrategy> InitStandardModuleStrategies()
    {
        return InitModuleStrategies(_standardSlots);
    }
    
    public List<IModuleStrategy> InitWeaponModuleStrategies()
    {
        return InitModuleStrategies(_weaponSlots);
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

    private List<IModuleStrategy> InitModuleStrategies(SlotController[] slotControllers)
    {
        var strategies = new List<IModuleStrategy>();

        for (int i = 0; i < slotControllers.Length; i++)
        {
            if (slotControllers[i].Empty) continue;

            var slot = slotControllers[i];
            var strategy = slot.ModuleView.InstantiateStrategy();
            if (strategy != null)
            {
                strategies.Add(strategy);
            }
        }

        return strategies;
    }
}
