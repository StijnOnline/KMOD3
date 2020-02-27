﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    abstract class DecoratorNode : BTNode {
        //public DecoratorNode(BlackBoard blackBoard) : base(blackBoard) { }

        public BTNode child;

        /// <summary>
        /// Make sure this node is added to a parent before adding nodes to this node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public BTNode setChild(BTNode node) {
            node.blackBoard = blackBoard;
            child = node;
            return child;
        }
    }
}
