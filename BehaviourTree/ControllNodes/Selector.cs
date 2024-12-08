using System.Collections.Generic;

namespace BT
{
    public class Selector : Node
    {
        // Constructors
        public Selector() : base() { }
        public Selector(List<Node> childrenNodes) : base(childrenNodes) { }

        // Eva. function (Logical 'or' statement)
        public override NodeState Evaluate()
        {
            foreach (Node node in childrenNodes)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FALIURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        continue;
                }
            }
            state = NodeState.FALIURE;
            return state;
        }
    }
}
