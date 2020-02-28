using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVD.BehaviourTree;
using Robocode;

namespace SVD {
    class TurnTowardsNode : ActionNode {

        //public TurnNode(BlackBoard blackBoard) : base(blackBoard) { }

        public override void init() {
        }

        public override Status process() {

            Robot robot = (Robot)blackBoard.getData(TestBlackboard.Vars.Robot);
            double target = (double)blackBoard.getData(TestBlackboard.Vars.Target);
            robot.TurnRight(Robocode.Util.Utils.NormalRelativeAngleDegrees(target - robot.Heading));

            return Status.Succes;
        }
    }
}
