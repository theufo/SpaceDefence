using System;
using DefaultNamespace.Views;
using UnityEngine;

namespace Configs.Strategies
{
    public class WeaponModuleStrategy : BaseModuleStrategy
    {
        public override ModuleType ModuleType => ModuleType.Weapon;
        public override string Description => $"Deals {_damage} damage, Cooldown: {_cooldown}sec";

        [SerializeField] private float _damage;
        [SerializeField] private float _cooldown;

        [SerializeField] private GameObject _shotPrefab;

        public Action OnShotActivated;

        private ShotView _shotView;

        public float Cooldown => _cooldown;
        public bool CanShoot { get; private set; }
        
        private float _shootTime;

        public override void StartModule()
        {
            _cooldown *= _battleStatsController.WeaponCooldownSpeed;
            
            var instance = Instantiate(_shotPrefab, transform);
            _shotView = instance.GetComponent<ShotView>();
            _shotView.Init(_damage);

            _shootTime = _cooldown;
            CanShoot = false;
        }

        public override void Activate()
        {
            if (!CanShoot) return;
            
            CanShoot = false;
            _shootTime = _cooldown;
            OnShotActivated?.Invoke();
            
            _shotView.Activate();
        }

        private void Update()
        {
            if (CanShoot) return;
            
            if (_shootTime > 0)
            {
                _shootTime -= Time.deltaTime;
            }
            else
            {
                CanShoot = true;
            }
        }
    }
}