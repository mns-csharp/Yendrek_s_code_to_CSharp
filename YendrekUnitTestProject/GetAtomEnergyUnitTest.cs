using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yendrek_s_code_to_CSharp;

namespace YendrekUnitTestProject
{
    /// <summary>
    /// Summary description for GetAtomEnergyUnitTest
    /// </summary>
    [TestClass]
    public class AtomEnergyUnitTest
    {
        [TestMethod]
        public void GetTotalnergyUnitTest()
        {
            List<Point2d> list = new List<Point2d>();
            list.Add(new Point2d(1.66666667, 1.66666667));
            list.Add(new Point2d(1.66666667, 3.33333333));//this index selected
            list.Add(new Point2d(3.33333333, 1.66666667));
            list.Add(new Point2d(3.33333333, 3.33333333));

            Program.polymer_chain_vec = list;

            double total = Program.GetTotalPolymerEnergy();

            Assert.AreEqual(total, -12);
        }

        [TestMethod]
        public void GetAtomEnergyUnitTest()
        {
            List<Point2d> list = new List<Point2d>();
            list.Add(new Point2d(1.66666667, 1.66666667));
            list.Add(new Point2d(1.66666667, 3.33333333));//this index selected
            list.Add(new Point2d(3.33333333, 1.66666667));
            list.Add(new Point2d(3.33333333, 3.33333333));

            int index = 1;

            Program.polymer_chain_vec = list;
            double en = Program.GetAtomicEnergy(index);

            double sum = -3;
            Assert.AreEqual(en, sum);

            list.Clear();
            list.Add(new Point2d(1.25, 1.25));
            list.Add(new Point2d(1.25, 2.5));
            list.Add(new Point2d(1.25, 3.75));
            list.Add(new Point2d(2.5,  1.25));
            list.Add(new Point2d(2.5, 2.5));
            list.Add(new Point2d(2.5,  3.75));
            list.Add(new Point2d(3.75, 1.25));
            list.Add(new Point2d(3.75, 2.5));
            list.Add(new Point2d(3.75, 3.75));
            sum = -8;

            en = Program.GetAtomicEnergy(index);
            Assert.AreEqual(en, sum);
        }

        [TestMethod]
        public void ListManipUnitTest()
        {
            List<Point2d> list = new List<Point2d>();
            list.Add(new Point2d(0, 1));
            list.Add(new Point2d(1, 0));

            list[0].X = 100;
            list[0].Y = 100;

            list[1] = new Point2d(200, 200); 

            Assert.AreEqual(list[0], new Point2d(100, 100));
            Assert.AreEqual(list[1], new Point2d(200, 200));
        }
    }
}
