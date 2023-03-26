using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using Configs.Strategies;
using UnityEngine;

namespace DefaultNamespace.Controllers
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

        public List<WeaponModuleStrategy> WeaponModules { get; private set; }
        
        public Action<float> OnHealthChanged;
        public Action<float> OnShieldChanged;

        private ShipConfig _shipConfig;
        private List<IModuleStrategy> _standardModuleStrategies;
        private List<IModuleStrategy> _weaponModuleStrategies;

        public void Init(ShipConfig shipConfig, List<IModuleStrategy> moduleStrategies, List<IModuleStrategy> weaponModuleStrategies)
        {
            _shipConfig = shipConfig;
            _standardModuleStrategies = moduleStrategies;
            _weaponModuleStrategies = weaponModuleStrategies;

            HealthMax = _shipConfig.Health;
            Health = _shipConfig.Health;
            ShieldMax = _shipConfig.Shield;
            Shield = _shipConfig.Shield / 2;

            SetupStrategies(_standardModuleStrategies);
            SetupStrategies(_weaponModuleStrategies);
            StartStrategies(_standardModuleStrategies);
            StartStrategies(_weaponModuleStrategies);
            
            WeaponModules = _weaponModuleStrategies.Cast<WeaponModuleStrategy>().ToList();
        }

        private void Update()
        {
            if (Shield < ShieldMax)
            {
                var shield = Shield + Time.deltaTime;
                Mathf.Clamp(shield, 0, ShieldMax);
                Shield = shield;
            }
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

        private void SetupStrategies(List<IModuleStrategy> moduleStrategies)
        {
            for (int i = 0; i < moduleStrategies.Count; i++)
            {
                var strategy = moduleStrategies[i];
                strategy.Setup(this);
            }
        }

        private void StartStrategies(List<IModuleStrategy> moduleStrategies)
        {
            for (int i = 0; i < moduleStrategies.Count; i++)
            {
                moduleStrategies[i].StartModule();
            }
        }
    }
}