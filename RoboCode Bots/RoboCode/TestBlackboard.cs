using SVD.BehaviourTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD {
    class TestBlackboard : BlackBoard{
        public TestBlackboard(Type e) : base(e) { }

        public enum Vars {
            Robot,
            FirePower,
            TargetDist,
            LastScan,
            ScanDelay,
            Target,
            ScanEvent
        }
    }

    

}
