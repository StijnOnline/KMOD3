using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    class SequenceNode : CompositeNode {

        public SequenceNode(BlackBoard blackBoard) : base(blackBoard) { }

        public override void init() {
        }

        public override Status process() {
            for(int i = 0; i < childs.Count; i++) {
                Status s = childs[i].process();
                if(s == Status.Running)
                    return Status.Running;
                else if(s == Status.Failure)
                    return Status.Failure;
            }
            return Status.Succes;
        }
    }
}
