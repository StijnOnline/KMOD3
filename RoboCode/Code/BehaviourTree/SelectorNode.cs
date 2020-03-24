using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    class SelectorNode : CompositeNode {


        public override Status process() {
            for(int i = 0; i < childs.Count; i++) {
                Status s = childs[i].process();
                if(s == Status.Succes) {
                    return Status.Succes;
                } else if(s == Status.Running)
                    return Status.Running;
            }
            return Status.Failure;
        }
    }
}
