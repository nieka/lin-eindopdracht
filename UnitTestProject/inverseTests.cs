using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using lin_eindopdracht;

namespace UnitTestProject
{
    [TestClass]
    public class inverseTests
    {
        [TestMethod]
        public void inversePositibeNumbers()
        {
            List<List<double>> matrix = new List<List<double>>();
            matrix.Add(new List<double> { 0, 1, 2 });
            matrix.Add(new List<double> { 1, 2, 4 });
            matrix.Add(new List<double> { 8, 4 , 2 });
           
            List<List<double>> uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { -2, 1 , 0 });
            uitkomst.Add(new List<double> { 5, -8.0 / 3.0, 1.0 / 3.0 });
            uitkomst.Add(new List<double> { -2,4.0/3.0,-1.0/6.0 });

            Assert.AreEqual(TestMethodes.MatrixAreEquel(Matrix3D.inverse(matrix), uitkomst), true);
        }

        [TestMethod]
        public void inverseImPosibleMatrix()
        {
            List<List<double>> matrix = new List<List<double>>();
            matrix.Add(new List<double> { 1, 2, 3 });
            matrix.Add(new List<double> { 4, 5, 6 });
            matrix.Add(new List<double> { 7, 8, 9 });

            Assert.AreEqual(Matrix3D.inverse(matrix), null);
        }

        [TestMethod]
        public void inverseWithEmptyMatrix()
        {
            List<List<double>> matrix = new List<List<double>>();

            Assert.AreEqual(Matrix3D.inverse(matrix), null);
        }
    }
}
