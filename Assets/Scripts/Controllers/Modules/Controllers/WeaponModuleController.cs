using System;
using Configs;
using Configs.Impl;
using DefaultNamespace.Views;
using Object = UnityEngine.Object;

namespace Controllers.Modules
{
    public class WeaponModuleController : BaseModuleController
    {
        public Action OnShotActivated;

        private ShotView _shotView;
        public float Cooldown { get; private set; }
        public float Damage { get; private set; }
        
        public bool CanShoot { get; private set; }
        
        private float _shootTime;

        public WeaponModuleController(ModuleView moduleView, BattleStatsController battleStatsController) : base(moduleView, battleStatsController)
        {
            var weaponConfig = (WeaponModuleConfig) moduleView.GetConfig();
            Cooldown = weaponConfig.Cooldown;
            Damage = weaponConfig.Damage;

            Cooldown *= _battleStatsController.WeaponCooldownSpeed;
            
            var instance = Object.Instantiate(weaponConfig.ShotPrefab, moduleView.transform);
            _shotView = instance.GetComponent<ShotView>();
            _shotView.Init(Damage);

            _shootTime = Cooldown;
            CanShoot = false;
        }

        public override void Activate()
        {
            if (!CanShoot) return;
            
            CanShoot = false;
            _shootTime = Cooldown;
            OnShotActivated?.Invoke();
            
            _shotView.Activate();
        }

        public override void Update(float deltaTime)
        {
            if (CanShoot) return;
            
            if (_shootTime > 0)
            {
                _shootTime -= deltaTime;
            }
            else
            {
                CanShoot = true;
            }
        }
    }
}
