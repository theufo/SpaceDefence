using DefaultNamespace.Common.BehaviorTree;
using UnityEngine;

namespace Controllers.CharacterControllers.BehaviorTreeNodes
{
    public class RandomSelectorNode : Node
    {
        public override NodeState Evaluate()
        {
            var number = Random.Range(0, _children.Count);

            Debug.Log($"[BehaviorTree] Entered RandomSelector, selected={_children[number].GetType().Name}");

            return _children[number].Evaluate();
        }
    }
}
