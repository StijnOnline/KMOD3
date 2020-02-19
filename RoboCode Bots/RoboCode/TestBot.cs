
using Robocode;
using Robocode.Util;
using SVD.BehaviourTree;
using System.Drawing;

namespace SVD {
    public class TestBot : Robot {

        TestTree tree;
        bool scanning = true;
        double target;

        

        public override void Run() {
            Ahead(1000);
            tree = new TestTree();
            tree.init(this);

            CompositeNode sequencer = new SequenceNode(tree.blackBoard);

            tree.masterNode = sequencer;

            sequencer.childs.Add(new TurnNode(tree.blackBoard));
            sequencer.childs.Add(new TurnNode(tree.blackBoard));

            //BTNode.Status s;
            //do {
            //    s = tree.process();
            //}
            //while(s == BTNode.Status.Running);
            


            IsAdjustGunForRobotTurn = true;
            

            //while(scanning) {
            //    //based on location guess best spin direction
            //    FastScan(true);
            //}
            //    TurnGunRight(Utils.NormalRelativeAngleDegrees(target- GunHeading));
            //while(true) {
            //    Fire(5);
            //}





            

        }

        void FastScan(bool right) {
            IsAdjustRadarForGunTurn = false;
            TurnGunRight(20 * (right ? 1 : -1));
            TurnRadarRight(45 * (right ? 1 : -1));
            IsAdjustRadarForGunTurn = true;
        }


        public override void OnScannedRobot(ScannedRobotEvent evnt) {
            //Scan() if inside, then will restart this func
            scanning = false;


            target = Utils.NormalRelativeAngleDegrees(Heading + evnt.Bearing);

            //TurnRadarRight(2.0 * Utils.NormalRelativeAngleDegrees(Heading + evnt.Bearing - RadarHeading));
            
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
