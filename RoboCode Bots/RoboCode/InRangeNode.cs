﻿using Robocode;
using SVD.BehaviourTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD {
    class InRangeNode : ActionNode {
        //public CheckGunHeatNode(BlackBoard blackBoard) : base(blackBoard) { }

        public override void init() {
        }

        public override Status process() {
            Robot robot = (Robot)blackBoard.getData(TestBlackboard.Vars.Robot);


            if(robot.GunHeat < robot.GunCoolingRate)
                return Status.Succes;
            else
            
            return Status.Failure;
                
        }
    }
}
