using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;

namespace SVD {
    public class TestBot : Robot {
        public override void Run() {
            IsAdjustGunForRobotTurn = true;
            IsAdjustRadarForGunTurn = true;
            IsAdjustRadarForRobotTurn = true;


            while(true) {
                TurnRight(5);
            }

            

        }


        public override void OnScannedRobot(ScannedRobotEvent evnt) {
            //Scan() if inside, then will restart this func
        }


        public override void OnBulletHit(BulletHitEvent evnt) {
        }


        public override void OnHitByBullet(HitByBulletEvent evnt) {

        }







        public override void OnWin(WinEvent evnt) {
            while(true) {
                TurnRight(30);
                TurnRight(-30);
            }
        }



        public override void OnRobotDeath(RobotDeathEvent evnt) {

        }

        public override void OnBattleEnded(BattleEndedEvent evnt) {
        }
    }
}
