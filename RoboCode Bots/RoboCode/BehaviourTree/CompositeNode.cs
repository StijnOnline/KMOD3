using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    abstract class CompositeNode : BTNode {
        public List<BTNode> childs = new List<BTNode>();

        public CompositeNode(BlackBoard blackBoard) : base(blackBoard) { }

        /// <summary>
        /// Returns this Node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public CompositeNode addChild(BTNode node) {
            childs.Add(node);
            return this;
        }
    }
}
