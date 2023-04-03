using UnityEngine;

namespace Controllers.CharacterControllers
{
    public class PlayerController : BaseCharacterController
    {
        public override string CharacterName => "Player";

        public override void MoveRight()
        {
            if (_cellsController.TryMoveRight(out var position))
            {
                transform.position = position;
            }
        }

        public override void MoveLeft()
        {
            if (_cellsController.TryMoveLeft(out var position))
            {
                transform.position = position;
            }
        }

        public override void MoveUp()
        {
            if (_cellsController.TryMoveUp(out var position))
            {
                transform.position = position;
            }
        }

        public override void MoveDown()
        {
            if (_cellsController.TryMoveDown(out var position))
            {
                transform.position = position;
            }
        }

        public override void FireWeapon1()
        {
            if (_weaponModuleStrategies.Count > 0)
            {
                _weaponModuleStrategies[0]?.Activate();
            }
        }

        public override void FireWeapon2()
        {
            if (_weaponModuleStrategies.Count > 1)
            {
                _weaponModuleStrategies[1]?.Activate();
            }
        }

        private void Update()
        {
            if (!_enabled) return;

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveUp();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveDown();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                FireWeapon1();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                FireWeapon2();
            }
        }
    }
}
