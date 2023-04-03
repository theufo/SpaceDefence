using Assets.Scripts.Core.WindowSystem;
using Configs.Strategies;
using UnityEngine;
using UnityEngine.UI;

namespace UI.BattleScreen
{
    public class WeaponButtonComponent : ScreenComponent
    {
        [SerializeField] private Image _progressBar;

        private WeaponModuleStrategy _weaponModuleStrategy;
        private float _cooldown;
        private float _shootTime;

        private bool _disabled;

        public void SetInfo(WeaponModuleStrategy weaponModule)
        {
            if (weaponModule == null)
            {
                _disabled = true;
                _progressBar.fillAmount = 0;
                return;
            }
            _cooldown = weaponModule.Cooldown;
            weaponModule.OnShotActivated += OnShotActivated;
        
            OnShotActivated();
        }

        public override void OnHide()
        {
            base.OnHide();

            _weaponModuleStrategy.OnShotActivated -= OnShotActivated;
        }

        private void OnShotActivated()
        {
            _progressBar.fillAmount = 0;
            _shootTime = _cooldown;
        }

        private void Update()
        {
            if (_disabled) return;
            if (_progressBar.fillAmount >= 1) return;

            _shootTime -= Time.deltaTime;
            _progressBar.fillAmount = 1 - (_shootTime / _cooldown);
        }
    }
}
