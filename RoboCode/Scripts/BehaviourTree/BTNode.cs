using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    abstract class BTNode {
        public BlackBoard blackBoard;

        public abstract Status process();

        public enum Status {
            Running,
            Failure,
            Succes
        }
    }
}
