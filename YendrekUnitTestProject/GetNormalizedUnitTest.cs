using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yendrek_s_code_to_CSharp;

namespace YendrekUnitTestProject
{
    [TestClass]
    public class GetNormalizedUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            double val = random.GetNormalized(0, -5, 5);
            Assert.AreEqual(val, -5);

            val = random.GetNormalized(0.50, 0, 100);
            Assert.AreEqual(val, 50);

            val = random.GetNormalized(0.50, -1, 1);
            Assert.AreEqual(val, 0);
        }
    }
}
