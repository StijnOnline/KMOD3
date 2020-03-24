using Robocode;
using SVD.BehaviourTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD {
    class DoNothingNode : ActionNode {
       

        public override Status process() {
            Robot robot = (Robot)blackBoard.getData(TestBlackboard.Vars.Robot);
            robot.DoNothing();
            return Status.Succes;
        }
    }
}
