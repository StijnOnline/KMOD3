using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVD.BehaviourTree;
using Robocode;
using System.Drawing;

namespace SVD {
    class ScanNode : ActionNode {

        //public ScanNode(BlackBoard blackBoard) : base(blackBoard) { }

        public override void init() {
        }

        public override Status process() {
            //also see OnScannedRobot in the main robot script
            Robot robot = blackBoard.getData<Robot>("Robot");
            robot.TurnRadarRight(45 /** (right ? 1 : -1)*/);

            robot.Out.WriteLine("Scan Node");
            robot.SetAllColors(Color.Red);

            return Status.Succes;
        }
    }
}
