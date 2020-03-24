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

        public override Status process() {
            //also see OnScannedRobot in the main robot script

            Robot robot = (Robot)blackBoard.getData(TestBlackboard.Vars.Robot);
            robot.TurnRadarRight(45);

            robot.Out.WriteLine("Scan Node");
            
            return Status.Succes;
        }
    }
}
