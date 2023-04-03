using System;
using DefaultNamespace.Common.BehaviorTree;
using UnityEngine;

namespace Controllers.CharacterControllers.BehaviorTreeNodes
{
    public class MoveNode : Node
    {
        private Func<bool> _condition;
        private Action _trueAction;

        public void Setup(Func<bool> condition, Action trueAction)
        {
            _condition = condition;
            _trueAction = trueAction;
        }

        public override NodeState Evaluate()
        {
            if (_condition.Invoke())
            {
                Debug.Log($"[BehaviorTree] Entered MoveNode, Invoked {_trueAction.Method.Name}");

                _trueAction.Invoke();

                return NodeState.Success;
            }

            Debug.Log($"[BehaviorTree] Entered MoveNode, Not invoked {_trueAction.Method.Name}");

            return NodeState.Failed;
        }
    }
}
