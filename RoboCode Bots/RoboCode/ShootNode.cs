using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVD.BehaviourTree;
using Robocode;
using Robocode.Util;

namespace SVD {
    class ShootNode : ActionNode {

        public ShootNode(BlackBoard blackBoard) : base(blackBoard) { }

        public override void init() {
        }

        public override Status process() {
            Robot robot = blackBoard.getData<Robot>("Robot");
            if(robot.GunHeat != 0)
                return Status.Failure;

            double target = blackBoard.getData<double>("Target");            
            robot.TurnGunRight(Utils.NormalRelativeAngleDegrees(target - robot.GunHeading));            
            robot.Fire(1);
            return Status.Succes;
        }
    }
}
