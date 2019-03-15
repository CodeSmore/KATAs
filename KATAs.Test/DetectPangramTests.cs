using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KATAs.Test
{
    [TestClass]
    public class DetectPangramTests
    {
        [TestMethod]
        public void Test001_GivenDetectPangram_WhenInputIsNotAPangram_ThenIsPangramReturnsFalse()
        {
            string input = "Not a pangram.";

            Assert.IsFalse(DetectPangram.IsPangram(input));
        }
    }
}
