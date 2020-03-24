using SVD.BehaviourTree;
using Robocode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD {
    class DriveNode : ActionNode {
        

        public override Status process() {
            Robot robot = (Robot)blackBoard.getData(TestBlackboard.Vars.Robot);
            robot.Ahead(Rules.MAX_VELOCITY);
            return Status.Succes;
        }
    }
}
