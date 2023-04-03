using Controllers.CharacterControllers.BehaviorTreeNodes;
using DefaultNamespace.Common.BehaviorTree;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers.CharacterControllers
{
    public class EnemyController : BaseCharacterController
    {
        public override string CharacterName => "Enemy";

        private BehaviorTree _tree;
        private float _waitTime;

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
            _weaponModuleControllers[0]?.Activate();
        }

        public override void FireWeapon2()
        {
            _weaponModuleControllers[1]?.Activate();
        }

        public void InitBehaviorTree()
        {
            _tree = new BehaviorTree();

            var fireNode1 = new FireNode();
            fireNode1.Setup(_weaponModuleControllers[0], FireWeapon1);
            var fireNode2 = new FireNode();
            fireNode2.Setup(_weaponModuleControllers[1], FireWeapon2);

            var moveRightNode = new MoveNode();
            moveRightNode.Setup(_cellsController.CanMoveRight, MoveRight);
            
            var moveLeftNode = new MoveNode();
            moveLeftNode.Setup(_cellsController.CanMoveLeft, MoveLeft);

            var moveUpNode = new MoveNode();
            moveUpNode.Setup(_cellsController.CanMoveUp, MoveUp);
            
            var moveDownNode = new MoveNode();
            moveDownNode.Setup(_cellsController.CanMoveDown, MoveDown);

            var moveRandomSelector = new RandomSelectorNode();
            moveRandomSelector.Attach(moveRightNode);
            moveRandomSelector.Attach(moveLeftNode);
            moveRandomSelector.Attach(moveUpNode);
            moveRandomSelector.Attach(moveDownNode);
            
            var fireRandomSelector = new RandomSelectorNode();
            fireRandomSelector.Attach(fireNode1);
            fireRandomSelector.Attach(fireNode2);
            
            _tree.Root = new SequenceNode();
            _tree.Root.Attach(moveRandomSelector);
            _tree.Root.Attach(fireRandomSelector);
        }

        private void Update()
        {
            if(!_enabled) return;

            _waitTime -= Time.deltaTime;

            if (_waitTime > 0) return;

            _waitTime = Random.Range(1, 3);

            _tree.Start();
        }
    }
}
