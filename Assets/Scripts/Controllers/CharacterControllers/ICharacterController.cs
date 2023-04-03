using System.Collections.Generic;
using Configs.Strategies;
using Controllers.CellControllers;

namespace Controllers.CharacterControllers
{
    public interface ICharacterController
    {
        string CharacterName { get; set; }

        void Init(CellsController cellsController, List<WeaponModuleStrategy> weaponModuleStrategies);
        void MoveRight();
        void MoveLeft();
        void MoveUp();
        void MoveDown();
        void FireWeapon1();
        void FireWeapon2();
    }
}