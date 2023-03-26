using DefaultNamespace.Common.BehaviorTree;
using UnityEngine;

namespace DefaultNamespace.Controllers.BehaviorTreeNodes
{
    public class SequenceNode : Node
    {
        public override NodeState Evaluate()
        {
            Debug.Log($"[BehaviorTree] Entered sequence");
            foreach (var child in _children)
            {
                child.Evaluate();
            }

            return NodeState.Success;
        }
    }
}