using Robocode;
using SVD.BehaviourTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD {
    class InRangeNode : ActionNode {
        

        public override Status process() {

            ScannedRobotEvent ev = (ScannedRobotEvent) blackBoard.getData(TestBlackboard.Vars.ScanEvent);
            double maxDist = (double) blackBoard.getData(TestBlackboard.Vars.MaxDist);
            

            if(ev.Distance < maxDist)
                return Status.Succes;
            else            
                return Status.Failure;
                
        }
    }
}
