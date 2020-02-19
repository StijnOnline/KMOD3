using SVD.BehaviourTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;

namespace SVD {
    class TestTree : BehaviourTree.BehaviourTree {

        public void init(Robot robot) {
            blackBoard = new BlackBoard();
            
            blackBoard.setData("Dir",90d);
            blackBoard.setData("Robot", robot);
        }

        public void process() {
            masterNode.process();
        }
    }
}
