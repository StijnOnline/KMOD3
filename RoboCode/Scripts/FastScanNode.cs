using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVD.BehaviourTree;
using Robocode;
using System.Drawing;

namespace SVD {
    class FastScanNode : ActionNode {

        //public ScanNode(BlackBoard blackBoard) : base(blackBoard) { }

        public override void init() {
        }

        public override Status process() {
            //also see OnScannedRobot in the main robot script

            Robot robot = (Robot)blackBoard.getData(TestBlackboard.Vars.Robot);

            robot.IsAdjustGunForRobotTurn = false;
            robot.TurnRight(20);
            robot.TurnRadarRight(45);
            robot.IsAdjustGunForRobotTurn = true;



            
            return Status.Succes;
        }
    }
}
