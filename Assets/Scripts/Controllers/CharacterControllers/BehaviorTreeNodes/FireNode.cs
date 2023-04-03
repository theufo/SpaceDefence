using System;
using Configs.Strategies;
using DefaultNamespace.Common.BehaviorTree;
using UnityEngine;

namespace Controllers.CharacterControllers.BehaviorTreeNodes
{
    public class FireNode : Node
    {
        private WeaponModuleStrategy _strategy;
        private Action _action;

        public void Setup(WeaponModuleStrategy strategy, Action action)
        {
            _strategy = strategy;
            _action = action;
        }

        public override NodeState Evaluate()
        {
            Debug.Log($"[BehaviorTree] Entered FireNode, CanShoot={_strategy.CanShoot}  FireMethod={_action.Method.Name}");

            if (_strategy.CanShoot)
            {
                _action.Invoke();
            }

            return NodeState.Success;
        }
    }
}