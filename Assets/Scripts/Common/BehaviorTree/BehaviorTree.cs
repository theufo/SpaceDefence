namespace DefaultNamespace.Common.BehaviorTree
{
    public class BehaviorTree
    {
        public Node Root;

        public void Start()
        {
            Root.Evaluate();
        }
    }
}
