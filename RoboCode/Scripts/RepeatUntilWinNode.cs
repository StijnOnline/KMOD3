using Robocode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    class RepeatUntilWinNode : DecoratorNode {

        public override Status process() {

            Robot robot = (Robot)blackBoard.getData(TestBlackboard.Vars.Robot);

            if(robot.Others != 0) {
                child.process();
                return Status.Running;
            }

            return Status.Succes;
        }
    }
}
