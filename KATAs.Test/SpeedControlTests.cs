using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace KATAs.Test
{
    [TestClass]
    public class SpeedControlTests
    {
        [TestMethod]
        public void Test001_GivenSpeedControl_WhenLessThanTwoDistanceSamplesExist_ThenZeroIsReturned()
        {
            double[] distanceSamples = new double[] { 0.0 };
            int seconds = 25;

            int expectedResult = 0;
            int actualResult = SpeedControl.GetMaxAverageSpeedPerHour(seconds, distanceSamples);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test002_GivenSpeedControl_WhenTwoDistanceSamplesExist_ThenReturnTheCorrectSpeed()
        {
            double[] distanceSamples = new double[] { 0.0, 0.19 };
            int seconds = 15;

            int expectedResult = 45;
            int actualResult = SpeedControl.GetMaxAverageSpeedPerHour(seconds, distanceSamples);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Test003_GivenSpeedControl_WhenMoreThanTwoDistanceSamplesExist_ThenReturnTheCorrectSpeed()
        {
            double[] distanceSamples = new double[] { 0.0, 0.19, 0.5, 0.75, 1.0, 1.25, 1.5, 1.75, 2.0, 2.25 };
            int seconds = 15;

            int expectedResult = 74;
            int actualResult = SpeedControl.GetMaxAverageSpeedPerHour(seconds, distanceSamples);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestHelperMethod001_GivenSpeedControl_WhenGetDistanceSegmentsHelperMethodIsCalled_ThenReturnTheDistanceBetweenEachSegment()
        {
            double[] distanceSamples = new double[] { 0.0, 0.19, 0.5, 0.75, 1.0, 1.25, 1.5, 1.75, 2.0, 2.25 };

            double[] expectedResult = new double[] { 0.19, 0.31, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25 };
            double[] actualResult = SpeedControl.GetDistanceSegments(distanceSamples);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestHelperMethod002_GivenSpeedControl_WhenGetSegmentsAverageSpeedsMethodIsCalled_ThenReturnTheFloorIntegerAverageSpeedPerSegment()
        {
            double[] distanceSegments = new double[] { 0.19, 0.31, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25, 0.25 };
            int seconds = 15;

            int[] expectedResult = new int[] { 45, 74, 60, 60, 60, 60, 60, 60, 60 };
            int[] actualResult = SpeedControl.GetSegmentsAverageSpeeds(distanceSegments, seconds);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
