using System.Numerics;
using Robocode;
using Robocode.Util;
using SVD.BehaviourTree;
using System.Drawing;
using System;

namespace SVD {
    public class TestBot : Robot {

        TestTree tree;
        //bool scanning = true;
        //double target;
        //double estimatetarget;
        const float ESTIMATE_MULTIPLIER = 10;



        public override void Run() {
            IsAdjustGunForRobotTurn = true;
            int d = 1;

            //Test Tree
            {
                tree = new TestTree();
                tree.init(this);

                CompositeNode sequencer = new SequenceNode(tree.blackBoard);

                tree.masterNode = sequencer;

                //sequencer.addChild(new RepeatUntilSucces(tree.blackBoard).setChild(new FastScanNode(tree.blackBoard)));
                //sequencer.addChild(new RepeatUntilSucces(tree.blackBoard).setChild(new ShootNode(tree.blackBoard)));
                sequencer.addChild(new TurnNode(tree.blackBoard));
                sequencer.addChild(new TurnNode(tree.blackBoard));


                BTNode.Status s;
                do {
                    s = tree.process();
                }
                while(s == BTNode.Status.Running);
            }







            /*while(scanning) {
                based on location guess best spin direction
                Ahead(Rules.MAX_VELOCITY);
                FastScan(true);
            }
            TurnRadarRight(Utils.NormalRelativeAngleDegrees((target - RadarHeading)) - 45d / 2d);
            TurnGunRight(Utils.NormalRelativeAngleDegrees(target - GunHeading));
            while(true) {
                TurnRadarRight(Utils.NormalRelativeAngleDegrees((target - RadarHeading)) + 45d / 2d * d);
                d *= -1;
                if(GunHeat == 0) {

                    TurnGunRight(Utils.NormalRelativeAngleDegrees(estimatetarget - GunHeading));
                    Fire(1);
                //} else if(GunHeat - GunCoolingRate <= 0) {
                    //Ahead(Rules.MAX_VELOCITY);

                } else {
                    Ahead(Rules.MAX_VELOCITY);
                }

            }*/







        }


        public double PredictedGun(double bearing, double dist, double heading, double vel) {
            double radBearing = (bearing * Math.PI / 180);
            Vector2 toRobot = (float)dist * new Vector2((float)Math.Sin(radBearing), (float)Math.Cos(radBearing));

            double radHeading = (heading * Math.PI / 180);
            Vector2 botHeading = ESTIMATE_MULTIPLIER * (float)vel * new Vector2((float)Math.Cos(radHeading), (float)Math.Sin(radHeading));
            Vector2 predictedPos = (toRobot - botHeading);
            double tan = Math.Atan2(predictedPos.Y, predictedPos.X) / Math.PI * 180;
            tan = 90 - tan;
            return tan;
        }


        public override void OnScannedRobot(ScannedRobotEvent evnt) {
            //scanning = false;
            tree.blackBoard.setData("ScanSucces", true);
            double target = Utils.NormalRelativeAngleDegrees(Heading + evnt.Bearing);
            tree.blackBoard.setData("Target", target);
            //estimatetarget = PredictedGun(Utils.NormalRelativeAngleDegrees(Heading + evnt.Bearing), evnt.Distance, evnt.Heading, evnt.Velocity);

            //Lock
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
