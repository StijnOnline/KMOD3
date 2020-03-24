using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    class SequenceNode : CompositeNode {
        

        public override Status process() {
            int i = 0;
            while(i < childs.Count) {
                Status s = childs[i].process();
                if(s == Status.Succes) {
                    i++;
                } else if(s == Status.Running)
                    return Status.Running;
                else if(s == Status.Failure)
                    return Status.Failure;
            }
            return Status.Succes;
        }
    }
}
