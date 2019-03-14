using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace KATAs.Test
{
    [TestClass]
    public class TheHighestProfitWinsTests
    {
        [TestMethod]
        public void Test001_GivenTheHighestProfitWins_WhenInputIsAnArrayOfInts_ThenOutputIsAnArrayOfIntsWithLowestAndHighestValueFromInputArray()
        {
            TheHighestProfitWins highestProfitWins = new TheHighestProfitWins();

            int[] input = new int[] { 1, 2, 5, -1, 12, 20 };

            CollectionAssert.AreEqual(new int[] { -1, 20 }, highestProfitWins.MinMax(input));

            // ----------------------------------------------------------------------------------

            input = new int[] { 2334454, 5 };

            CollectionAssert.AreEqual(new int[] { 5, 2334454 }, highestProfitWins.MinMax(input));

            // ----------------------------------------------------------------------------------

            input = new int[] { 1 };

            CollectionAssert.AreEqual(new int[] { 1, 1 }, highestProfitWins.MinMax(input));
        }
    }
}
