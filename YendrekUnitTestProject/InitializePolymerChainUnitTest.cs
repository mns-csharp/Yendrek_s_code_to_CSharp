using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yendrek_s_code_to_CSharp;
using System.Collections.Generic;

namespace YendrekUnitTestProject
{
    [TestClass]
    public class InitializePolymerChainUnitTest
    {
        [TestMethod]
        public void InitializePolymerChain()
        {
            //Program.N = 4;
            //List<Point2d> polymer = Program.InitializePolymerChain();
            //Point2d point1 = polymer[0];
            //Assert.AreEqual(point1, new Point2d(1.66666667, 1.66666667));
        }

        [TestMethod]
        public void PolymerLengthCount()
        {
            Program.N = 4;
            List<Point2d> polymer = Program.InitializePolymerChain();
            Assert.AreEqual(polymer.Count, 4);

            Program.N = 5;
            List<Point2d> polymer2 = Program.InitializePolymerChain();
            Assert.AreEqual(polymer2.Count, 4);

            Program.N = 6;
            List<Point2d> polymer3 = Program.InitializePolymerChain();
            Assert.AreEqual(polymer3.Count, 4);

            Program.N = 7;
            List<Point2d> polymer4 = Program.InitializePolymerChain();
            Assert.AreEqual(polymer4.Count, 4);

            Program.N = 8;
            List<Point2d> polymer5 = Program.InitializePolymerChain();
            Assert.AreEqual(polymer5.Count, 4);

            Program.N = 9;
            List<Point2d> polymer6 = Program.InitializePolymerChain();
            Assert.AreEqual(polymer6.Count, 9);
        }
    }
}
