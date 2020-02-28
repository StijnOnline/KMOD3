using SVD.BehaviourTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;

namespace SVD {
    class TestTree : BehaviourTree.BehaviourTree {

        public TestTree(BlackBoard blackboard, Robot robot) {
            this.blackBoard = blackboard;
            blackBoard.setData(TestBlackboard.Vars.Robot,robot);
        }

        public void SetMaster(BTNode node) {
            masterNode = node;
            masterNode.blackBoard = blackBoard;
        }

        public override void init() {

        }

        public override BTNode.Status process() {
            return masterNode.process();
        }
    }
}
