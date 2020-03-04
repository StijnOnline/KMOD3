using System.Numerics;
using Robocode;
using Robocode.Util;
using SVD.BehaviourTree;
using System.Drawing;
using System;

namespace SVD {
    public class TestBot : Robot {

        TestTree tree;
        TestBlackboard blackBoard;

        //bool scanning = true;
        //double target;
        //double estimatetarget;
        const float ESTIMATE_MULTIPLIER = 10;



        public override void Run() {

            blackBoard = new TestBlackboard(typeof(TestBlackboard.Vars));
            tree = new TestTree(blackBoard, this);
            
            blackBoard.setData(TestBlackboard.Vars.FirePower, 5d);
            blackBoard.setData(TestBlackboard.Vars.LastScan, -10d);
            blackBoard.setData(TestBlackboard.Vars.ScanDelay,5d);
            blackBoard.setData(TestBlackboard.Vars.MaxDist,300d);

            //Build Tree
            {
                DecoratorNode repeater = new RepeatUntilWinNode();
                tree.SetMaster(repeater);
                CompositeNode sequencer = new SequenceNode();
                repeater.setChild(sequencer);
                //Scanning
                {
                    /*DecoratorNode scanInverter1 = new InverterNode();
                    sequencer.addChild(scanInverter1);
                    CompositeNode scanSequencer = new SequenceNode();
                    scanInverter1.setChild(scanSequencer);

                    DecoratorNode scanInverter2 = new InverterNode();
                    scanSequencer.addChild(new ChangeColorNode(Color.Blue));
                    scanSequencer.addChild(scanInverter2);
                    scanInverter2.setChild(new RecentlyScannedNode());*/
                    //scanSequencer.addChild(new ScanNode());
                    //sequencer.addChild(new ScanNode());


                    CompositeNode scanSelector = new SelectorNode();
                    sequencer.addChild(scanSelector);
                    CompositeNode scanSequencer = new SequenceNode();
                    scanSelector.addChild(scanSequencer);
                    scanSequencer.addChild(new RecentlyScannedNode());
                    scanSequencer.addChild(new ScanLockNode());
                    scanSelector.addChild(new FastScanNode());

                }
                CompositeNode selector = new SelectorNode();
                sequencer.addChild(selector);
                //Move to range
                {
                    CompositeNode MoveToRangeSequencer = new SequenceNode();
                    selector.addChild(MoveToRangeSequencer);

                    MoveToRangeSequencer.addChild(new ChangeColorNode(Color.Green));
                    MoveToRangeSequencer.addChild(new RecentlyScannedNode());
                    DecoratorNode MoveToRangeInverter = new InverterNode();
                    MoveToRangeSequencer.addChild(MoveToRangeInverter);
                    MoveToRangeInverter.setChild(new InRangeNode());
                    MoveToRangeSequencer.addChild(new TurnTowardsNode());
                    MoveToRangeSequencer.addChild(new DriveNode());
                }
                // Shooting
                {
                    CompositeNode shootingSequencer = new SequenceNode();
                    selector.addChild(shootingSequencer);

                    shootingSequencer.addChild(new RecentlyScannedNode());
                    shootingSequencer.addChild(new ChangeColorNode(Color.Red));
                    shootingSequencer.addChild(new CheckGunHeatNode());
                    shootingSequencer.addChild(new FastScanNode());
                    shootingSequencer.addChild(new ShootNode());
                }
                selector.addChild(new DoNothingNode());
            }
            Out.WriteLine("Created Behaviour tree");

            //Run Tree
            {
                BTNode.Status s;
                do {
                    s = tree.process();
                }
                while(s == BTNode.Status.Running);
            }

            //Old Manual Code
            {
                //IsAdjustGunForRobotTurn = true;
                //int d = 1;

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
            blackBoard.setData(TestBlackboard.Vars.LastScan, (double) Time);
            blackBoard.setData(TestBlackboard.Vars.ScanEvent, evnt);
            double target = Utils.NormalRelativeAngleDegrees(Heading + evnt.Bearing);
            blackBoard.setData(TestBlackboard.Vars.Target, target);

            
            //estimatetarget = PredictedGun(Utils.NormalRelativeAngleDegrees(Heading + evnt.Bearing), evnt.Distance, evnt.Heading, evnt.Velocity);
            
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
