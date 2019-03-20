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
    }
}
