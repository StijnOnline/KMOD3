using Robocode;
using SVD.BehaviourTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD {
    class RecentlyScannedNode : ActionNode {

        public override Status process() {

            Robot robot = (Robot)blackBoard.getData(TestBlackboard.Vars.Robot);
            double lastScan = (double)blackBoard.getData(TestBlackboard.Vars.LastScan);
            double ScanDelay = (double)blackBoard.getData(TestBlackboard.Vars.ScanDelay);
            if(lastScan + ScanDelay > robot.Time)
                return Status.Succes;
            else
                return Status.Failure;
        }
    }
}
