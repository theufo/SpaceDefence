using System;
using Configs.Strategies;
using Controllers.Modules;
using DefaultNamespace.Common.BehaviorTree;
using UnityEngine;

namespace Controllers.CharacterControllers.BehaviorTreeNodes
{
    public class FireNode : Node
    {
        private WeaponModuleController _controller;
        private Action _action;

        public void Setup(WeaponModuleController controller, Action action)
        {
            _controller = controller;
            _action = action;
        }

        public override NodeState Evaluate()
        {
            Debug.Log($"[BehaviorTree] Entered FireNode, CanShoot={_controller.CanShoot}  FireMethod={_action.Method.Name}");

            if (_controller.CanShoot)
            {
                _action.Invoke();
            }

            return NodeState.Success;
        }
    }
}