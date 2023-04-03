using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using Controllers.CharacterControllers;
using Controllers.Modules;
using Managers.Battle;
using UnityEngine;
using Utils;

namespace Controllers
{
    public class BattleStatsController : MonoBehaviour
    {
        public float HealthMax { get; private set; }
        public float ShieldMax { get; private set; }
        
        private float _shield;
        public float Shield
        {
            get => _shield;
            private set
            {
                _shield = value;
                OnShieldChanged?.Invoke(_shield);
            }
        }
        
        private float _health;
        public float Health
        {
            get => _health;
            private set
            {
                _health = value;
                OnHealthChanged?.Invoke(_health);
            }
        }

        public float WeaponCooldownSpeed { get; private set; } = 1;
        public float ShieldRechargeSpeed { get; private set; } = 1;

        public List<WeaponModuleController> WeaponModules { get; private set; }
        
        public Action<float> OnHealthChanged;
        public Action<float> OnShieldChanged;

        private ShipConfig _shipConfig;
        private List<IModuleController> _standardModules;
        private List<IModuleController> _weaponModules;

        public void Init(ShipConfig shipConfig, List<ModuleView> standardModuleConfigs, List<ModuleView> weaponModuleConfigs)
        {
            _shipConfig = shipConfig;

            HealthMax = _shipConfig.Health;
            Health = _shipConfig.Health;
            ShieldMax = _shipConfig.Shield;
            Shield = _shipConfig.Shield / 2;

            _standardModules = SetupModules(standardModuleConfigs);
            _weaponModules = SetupModules(weaponModuleConfigs);
            
            WeaponModules = _weaponModules.Cast<WeaponModuleController>().ToList();
        }

        private void Update()
        {
            if (Shield < ShieldMax)
            {
                var shield = Shield + Time.deltaTime;
                Mathf.Clamp(shield, 0, ShieldMax);
                Shield = shield;
            }

            UpdateModules(_standardModules);
            UpdateModules(_weaponModules);
        }

        public void ModifyWeaponCooldownSpeed(float value)
        {
            WeaponCooldownSpeed *= 1 - value;
        }

        public void ModifyShieldCooldownSpeed(float value)
        {
            ShieldRechargeSpeed *= 1 - value;
        }

        public void ModifyMaxHealth(float value)
        {
            HealthMax += value;
            Health = HealthMax;
        }

        public void ModifyMaxShield(float value)
        {
            ShieldMax += value;
        }

        public void ReceiveDamage(float value)
        {
            var damage = value;

            if (Shield > value)
            {
                Shield -= value;
            }
            else
            {
                damage -= Shield;
                Shield = 0;
                Health -= damage;
                
                if (Health <= 0)
                {
                    BattleManager.Instance.EndBattle(gameObject.GetComponent<ICharacterController>());
                }
            }
        }

        private List<IModuleController> SetupModules(List<ModuleView> moduleViews)
        {
            var list = new List<IModuleController>(moduleViews.Count);
            for (int i = 0; i < moduleViews.Count; i++)
            {
                var moduleView = moduleViews[i];
                list.Add(FactoryUtils.ProduceModuleController(moduleView, this));
            }

            return list;
        }

        private void UpdateModules(List<IModuleController> moduleControllers)
        {
            foreach (var module in moduleControllers)
            {
                module.Update(Time.deltaTime);
            }
        }
    }
}
