using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVD.BehaviourTree;
using Robocode;

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

            Robot robot = (Robot)blackBoard.getData(TestBlackboard.Vars.Robot);
            double target = (double)blackBoard.getData(TestBlackboard.Vars.Target);
            double power = (double)blackBoard.getData(TestBlackboard.Vars.FirePower);

            robot.TurnGunRight(Robocode.Util.Utils.NormalRelativeAngleDegrees(target - robot.GunHeading));
            robot.Fire(power);


            return Status.Succes;
        }
    }
}
