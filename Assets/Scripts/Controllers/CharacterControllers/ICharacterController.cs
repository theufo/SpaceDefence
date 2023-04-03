using System.Collections.Generic;
using Controllers.CellControllers;
using Controllers.Modules;

namespace Controllers.CharacterControllers
{
    public interface ICharacterController
    {
        string CharacterName { get; set; }

        void Init(CellsController cellsController, List<WeaponModuleController> weaponModuleControllers);
        void MoveRight();
        void MoveLeft();
        void MoveUp();
        void MoveDown();
        void FireWeapon1();
        void FireWeapon2();
    }
}