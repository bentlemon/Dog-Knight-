using UnityEngine;

namespace BT
{
    // Generic behaviour tree setup
    public abstract class BTree : MonoBehaviour
    {
        private Node _root = null; // Contains the whole tree

        private void Start()
        {
            _root = SetupBTree();
        }

        private void Update()
        {
            _root?.Evaluate();
        }

        protected abstract Node SetupBTree();
    }
}
