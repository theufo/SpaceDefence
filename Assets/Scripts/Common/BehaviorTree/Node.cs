using System.Collections.Generic;

namespace DefaultNamespace.Common.BehaviorTree
{
    public abstract class Node
    {
        public Node Parent;
        protected List<Node> _children = new List<Node>();

        public void Attach(Node node)
        {
            node.Parent = this;
            _children.Add(node);
        }

        public virtual NodeState Evaluate()
        {
            return NodeState.Failed;
        }
    }
}
