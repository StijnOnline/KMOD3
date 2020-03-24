using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVD.BehaviourTree;
using Robocode;

namespace SVD {
    class TurnNode : ActionNode {

        public override Status process() {

            Robot robot = (Robot)blackBoard.getData(TestBlackboard.Vars.Robot);
            robot.TurnRight(10);

            return Status.Succes;
        }
    }
}
