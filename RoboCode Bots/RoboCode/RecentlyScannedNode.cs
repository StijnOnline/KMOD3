using Robocode;
using SVD.BehaviourTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD {
    class RecentlyScannedNode : ActionNode {

        //public RecentlyScannedNode(BlackBoard blackBoard) : base(blackBoard) { }

        public override void init() {
        }

        public override Status process() {

            Robot robot = (Robot)blackBoard.getData(TestBlackboard.Vars.Robot);
            double lastScan = (double)blackBoard.getData(TestBlackboard.Vars.LastScan);
            double ScanDelay = (double)blackBoard.getData(TestBlackboard.Vars.ScanDelay);
            robot.Out.WriteLine("Recently Scanned Node: " + (lastScan + ScanDelay > robot.Time));
            if(lastScan + ScanDelay > robot.Time)
                return Status.Succes;
            else
                return Status.Failure;
        }
    }
}
