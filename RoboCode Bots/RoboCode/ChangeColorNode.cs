using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVD.BehaviourTree;
using Robocode;
using System.Drawing;

namespace SVD {
    class ChangeColorNode : ActionNode {
        Color color;

        public ChangeColorNode(Color color){
            this.color = color;
        }

        public override void init() {
        }

        public override Status process() {

            Robot robot = (Robot)blackBoard.getData(TestBlackboard.Vars.Robot);
            robot.SetAllColors(color);

            return Status.Succes;
        }
    }
}
