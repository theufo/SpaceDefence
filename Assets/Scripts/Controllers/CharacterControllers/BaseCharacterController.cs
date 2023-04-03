using System.Collections.Generic;
using Configs.Strategies;
using Controllers.CellControllers;
using UnityEngine;

namespace Controllers.CharacterControllers
{
    public abstract class BaseCharacterController : MonoBehaviour, ICharacterController
    {
        public virtual string CharacterName { get; set; }
        
        protected CellsController _cellsController;
        protected List<WeaponModuleStrategy> _weaponModuleStrategies;
        protected bool _enabled;

        public void Init(CellsController cellsController, List<WeaponModuleStrategy> weaponModuleStrategies)
        {
            _cellsController = cellsController;
            _weaponModuleStrategies = weaponModuleStrategies;
            _enabled = true;
        }

        public virtual void MoveRight()
        {
        }

        public virtual void MoveLeft()
        {
        }

        public virtual void MoveUp()
        {
        }

        public virtual void MoveDown()
        {
        }

        public virtual void FireWeapon1()
        {
        }

        public virtual void FireWeapon2()
        {
        }

        public void Disable()
        {
            _enabled = false;
        }
    }
}