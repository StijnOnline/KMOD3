using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    abstract class CompositeNode : BTNode {
        public List<BTNode> childs = new List<BTNode>();

        //public CompositeNode(BlackBoard blackBoard) : base(blackBoard) { }

        /// <summary>
        /// Make sure this node is added to a parent before adding nodes to this node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public BTNode[] addChild(BTNode node) {
            node.blackBoard = blackBoard;
            childs.Add(node);
            return childs.ToArray();
        }
    }
}
