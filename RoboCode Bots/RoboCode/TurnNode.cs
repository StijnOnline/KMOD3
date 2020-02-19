using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVD.BehaviourTree;
using Robocode;

namespace SVD {
    class TurnNode : ActionNode {

        public TurnNode(BlackBoard blackBoard) : base(blackBoard) { }

        public override void init() {
        }

        public override Status process() {
            Robot robot = blackBoard.getData<Robot>("Robot");
            double dir = blackBoard.getData<double>("Dir");
            if(robot == null)
                return Status.Failure;

            robot.TurnRight(dir);
            return Status.Succes;
        }
    }
}
