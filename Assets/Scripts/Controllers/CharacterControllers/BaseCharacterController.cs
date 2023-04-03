using System.Collections.Generic;
using Configs.Strategies;
using Controllers.CellControllers;
using Controllers.Modules;
using UnityEngine;

namespace Controllers.CharacterControllers
{
    public abstract class BaseCharacterController : MonoBehaviour, ICharacterController
    {
        public virtual string CharacterName { get; set; }
        
        protected CellsController _cellsController;
        protected List<WeaponModuleController> _weaponModuleControllers;
        protected bool _enabled;

        public void Init(CellsController cellsController, List<WeaponModuleController> weaponModuleControllers)
        {
            _cellsController = cellsController;
            _weaponModuleControllers = weaponModuleControllers;
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