using Robocode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    class RepeatUntilWinNode : DecoratorNode {
        //public RepeatUntilWinNode(BlackBoard blackBoard) : base(blackBoard) { }
        public override void init() {
        }

        public override Status process() {
            Robot r = blackBoard.getData<Robot>("Robot");
            if(r == null)
                return Status.Failure;

            if(r.Others != 0) {
                child.process();
                return Status.Running;
            }
            return Status.Succes;
        }
    }
}
