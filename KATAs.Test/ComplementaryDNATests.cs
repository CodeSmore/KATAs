using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace KATAs.Test
{
    [TestClass]
    public class ComplementaryDNATests
    {
        [TestMethod]
        public void Test001_GivenComplementaryDNA_WhenInputHasAnA_ThenReplaceAWithT()
        {
            ComplementaryDNA compDNA = new ComplementaryDNA();

            string input = "DNA";

            Assert.AreEqual("DNT", compDNA.MakeComplement(input));
        }

        [TestMethod]
        public void Test002_GivenComplementaryDNA_WhenInputHasT_ThenReplaceTWithA()
        {
            ComplementaryDNA compDNA = new ComplementaryDNA();

            string input = "TNT";

            Assert.AreEqual("ANA", compDNA.MakeComplement(input));
        }
    }
}
