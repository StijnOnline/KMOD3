using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVD.BehaviourTree;
using Robocode;
using System.Drawing;

namespace SVD {
    class ScanLockNode : ActionNode {

        //public ScanNode(BlackBoard blackBoard) : base(blackBoard) { }

        public override void init() {
        }

        public override Status process() {
            //also see OnScannedRobot in the main robot script

            Robot robot = (Robot)blackBoard.getData(TestBlackboard.Vars.Robot);
            ScannedRobotEvent scanEvent = (ScannedRobotEvent)blackBoard.getData(TestBlackboard.Vars.ScanEvent);

            robot.TurnRadarRight(2.0 * Robocode.Util.Utils.NormalRelativeAngleDegrees(robot.Heading + scanEvent.Bearing - robot.RadarHeading));


            return Status.Succes;
        }
    }
}
