using System.Collections.Generic;

namespace BT
{
    public class Node
    {
        // For sharing data 
        private Dictionary<string, object> _data = new();

        // Node state
        protected NodeState state;

        // access both parent and children
        public Node parentNode;
        protected List<Node> childrenNodes = new();

        // Constructors - - -  
        public Node() { parentNode = null; }

        public Node(List<Node> childrenNodes)
        {
            foreach (Node node in childrenNodes)
            {
                AttachNode(node);
            }
        }

        // Class functions - - -

        // Virtual to make it unique for actions
        public virtual NodeState Evaluate() => NodeState.FALIURE;

        // Functions for setting, clearing and getting data
        public void AddData(string key, object value)
        {
            _data[key] = value;
        }

        public object GetData(string key)
        {
            if (_data.TryGetValue(key, out object value)) return value;

            Node node = parentNode;
            while (node != null)
            {
                value = node.GetData(key);

                if (value != null) return value;
                node = node.parentNode;
            }
            return null;
        }

        public bool RemoveData(string key)
        {
            if (_data.ContainsKey(key))
            {
                _data.Remove(key);
                return true;
            }

            // Loop until no parent node (top of tree)
            Node node = parentNode;
            while (node != null)
            {
                bool removed = node.RemoveData(key);

                if (removed) return true;
                node = node.parentNode;
            }
            return false;
        }

        private void AttachNode(Node node)
        {
            node.parentNode = this;
            childrenNodes.Add(node);
        }
    }
}