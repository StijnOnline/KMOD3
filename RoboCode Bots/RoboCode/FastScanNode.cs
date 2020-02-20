using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVD.BehaviourTree;
using Robocode;

namespace SVD {
    class FastScanNode : ActionNode {

        public FastScanNode(BlackBoard blackBoard) : base(blackBoard) { }

        public override void init() {
        }

        public override Status process() {
            //also see OnScannedRobot in the main robot script
            Robot robot = blackBoard.getData<Robot>("Robot");
            blackBoard.setData("ScanSucces",false);

            robot.IsAdjustRadarForGunTurn = false;
            robot.TurnGunRight(20 /** (right ? 1 : -1)*/);
            robot.TurnRadarRight(45 /** (right ? 1 : -1)*/);
            robot.IsAdjustRadarForGunTurn = true;

            if(blackBoard.getData<bool>("ScanSucces"))
                return Status.Succes;
            else
                return Status.Failure;
        }
    }
}
