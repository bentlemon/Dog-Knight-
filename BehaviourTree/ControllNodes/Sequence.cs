using System.Collections.Generic;

namespace BT
{
    public class Sequence : Node
    {
        // Constructors
        public Sequence() : base() { }
        public Sequence(List<Node> childrenNodes) : base(childrenNodes) { }

        // Eva. function (logical 'and' statement)
        public override NodeState Evaluate()
        {
            bool isAnyChildRunning = false;

            foreach (Node node in childrenNodes)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FALIURE:
                        state = NodeState.FALIURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        isAnyChildRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }
            state = isAnyChildRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }
    }
}