using UnityEngine;

namespace Configs.Impl
{
    [CreateAssetMenu(menuName = "SpaceDefence/Configs/WeaponModuleConfig")]
    public class WeaponModuleConfig : ModuleConfig
    {
        public override ModuleType ModuleType => ModuleType.Weapon;
        public override string Description => $"Deals {_damage} damage, Cooldown: {_cooldown}sec";

        [SerializeField] private float _damage;
        [SerializeField] private float _cooldown;

        [SerializeField] private GameObject _shotPrefab;

        public float Damage => _damage;
        public float Cooldown => _cooldown;
        public GameObject ShotPrefab => _shotPrefab;
    }
}