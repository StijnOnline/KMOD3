using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    abstract class BehaviourTree {
        public BTNode masterNode;
        public BlackBoard blackBoard;     
        public abstract BTNode.Status process();
    }
}