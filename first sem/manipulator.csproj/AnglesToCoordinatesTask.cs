using System;
using System.Drawing;
using NUnit.Framework;

namespace Manipulation
{
    public static class AnglesToCoordinatesTask
    {
        public static PointF[] GetJointPositions(double shoulder, double elbow, double wrist)
        {
            var elbowPos = FindPoint(Manipulator.UpperArm, shoulder, 0, 0);
            var foreamAngle = shoulder + Math.PI + elbow;
            var wristPos = FindPoint(Manipulator.Forearm, foreamAngle, elbowPos.X, elbowPos.Y);
            var palmAngle = foreamAngle + Math.PI + wrist;
            var palmEndPos = FindPoint(Manipulator.Palm, palmAngle, wristPos.X, wristPos.Y);
            
            return new PointF[]
            {
                elbowPos,
                wristPos,
                palmEndPos
            };
        }
        private static PointF FindPoint(float length, double angle, float x, float y)
        {
            var xcoord = length * Math.Sin(Math.PI / 2 - angle);
            var ycoord = length * Math.Sin(angle);
            return new PointF((float)xcoord + x, (float)ycoord + y);
        }
    }

    [TestFixture]
    public class AnglesToCoordinatesTask_Tests
    {
        [TestCase(Math.PI / 2, Math.PI / 2, Math.PI, Manipulator.Forearm + Manipulator.Palm, Manipulator.UpperArm)]
        [TestCase(Math.PI / 2, Math.PI, Math.PI, 0, Manipulator.Forearm + Manipulator.Palm + Manipulator.UpperArm)]
        [TestCase(0, Math.PI, Math.PI, Manipulator.Forearm + Manipulator.Palm + Manipulator.UpperArm, 0)]
        [TestCase(3 * Math.PI / 2, Math.PI, Math.PI, 0, -(Manipulator.Forearm + Manipulator.Palm + Manipulator.UpperArm))]
        
        public void TestGetJointPositions(double shoulder, double elbow, double wrist, double palmEndX, double palmEndY)
        {
            var joints = AnglesToCoordinatesTask.GetJointPositions(shoulder, elbow, wrist);
            Assert.AreEqual(palmEndX, joints[2].X, 1e-5, "palm endX");
            Assert.AreEqual(palmEndY, joints[2].Y, 1e-5, "palm endY");
            Assert.Fail("TODO: проверить, что расстояния между суставами равны длинам сегментов манипулятора!");
        }
    }
}