using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yendrek_s_code_to_CSharp;
using System.Collections.Generic;

namespace YendrekUnitTestProject
{
    [TestClass]
    public class NumPyUnitTest
    {
        [TestMethod]
        public void MeshGridTest()
        {
            List<double> x_list = new List<double>();
            x_list.Add(0);
            x_list.Add(1);
            x_list.Add(2);

            List<double> y_list = new List<double>();
            y_list.Add(0);
            y_list.Add(1);
            y_list.Add(2);

            List<Point2d> list = np.meshgrid(x_list, y_list).ToList();

            Assert.AreEqual(list[0], new Point2d(0, 0));
            Assert.AreEqual(list[1], new Point2d(0, 1));
            Assert.AreEqual(list[2], new Point2d(0, 2));
            Assert.AreEqual(list[3], new Point2d(1, 0));
            Assert.AreEqual(list[4], new Point2d(1, 1));
            Assert.AreEqual(list[5], new Point2d(1, 2));
            Assert.AreEqual(list[6], new Point2d(2, 0));
            Assert.AreEqual(list[7], new Point2d(2, 1));
            Assert.AreEqual(list[8], new Point2d(2, 2));
        }

        [TestMethod]
        public void LinSpaceTest()
        {
            List<double> list = np.linspace(-5.0, 5.0, 1);
            Assert.AreEqual(list[0], -5.0);

            List<double> list2 = np.linspace(-5.0, 5.0, 2);
            Assert.AreEqual(list2[0], -5.0);
            Assert.AreEqual(list2[1], 5.0);
            
            List<double> list3 = np.linspace(-5.0, 5.0, 4);
            Assert.AreEqual(list3[0], -5.0);
            Assert.AreEqual(Math.Round(list3[1], 3), -1.667);
            Assert.AreEqual(Math.Round(list3[2], 3), 1.667);
            Assert.AreEqual(list3[3], 5.0);
        }
    }
}
