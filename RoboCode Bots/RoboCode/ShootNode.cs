using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVD.BehaviourTree;
using Robocode;
using Robocode.Util;

namespace SVD {
    /// <summary>
    /// Attempts to shoot at the target
    /// Requires Target variable on blackboard
    /// Fails if GunHeat != 0
    /// </summary>
    class ShootNode : ActionNode {

        //public ShootNode(BlackBoard blackBoard) : base(blackBoard) { }

        public override void init() {
        }

        public override Status process() {
            Robot robot = blackBoard.getData<Robot>("Robot");
            double target = blackBoard.getData<double>("Target");
            double power = blackBoard.getData<double>("FirePower");

            robot.TurnGunRight(Utils.NormalRelativeAngleDegrees(target - robot.GunHeading));            
            robot.Fire(power);
            return Status.Succes;
        }
    }
}
