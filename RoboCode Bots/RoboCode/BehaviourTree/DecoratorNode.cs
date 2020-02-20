using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    abstract class DecoratorNode : BTNode {
        public DecoratorNode(BlackBoard blackBoard) : base(blackBoard) { }

        public BTNode child;

        /// <summary>
        /// Returns this node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public DecoratorNode setChild(BTNode node) {
            child = node;
            return this;
        }
    }
}
