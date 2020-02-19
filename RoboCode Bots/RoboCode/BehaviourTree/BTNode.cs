using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    abstract class BTNode {
        public enum Status {
            Running,
            Failure,
            Succes
        }

        public Status status;
        public BlackBoard blackBoard;

        public abstract void init();

        public abstract Status process();
    }
}
