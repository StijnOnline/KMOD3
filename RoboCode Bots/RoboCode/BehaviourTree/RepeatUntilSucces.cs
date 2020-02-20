using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    class RepeatUntilSucces : DecoratorNode {
        public RepeatUntilSucces(BlackBoard blackBoard) : base(blackBoard) { }
        public override void init() {
        }

        public override Status process() {
            Status s = child.process();
            if(s != Status.Succes)
                return Status.Running;
            return Status.Succes;
        }
    }
}
