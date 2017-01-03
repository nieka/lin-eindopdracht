using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using lin_eindopdracht;

namespace UnitTestProject
{
    [TestClass]
    public class DeterminantTest
    {
        [TestMethod]
        public void DeterminantWithPositiveNumbers()
        {
            List<List<double>> matrix = new List<List<double>>();
            matrix.Add(new List<double> { 0, 1, 2 });
            matrix.Add(new List<double> { 1, 2, 4 });
            matrix.Add(new List<double> { 8, 4, 2 });

            Assert.AreEqual(Matrix3D.Determinant(matrix), 6);
        }

        [TestMethod]
        public void DeterminantWithNegativeNumbers()
        {
            List<List<double>> matrix = new List<List<double>>();
            matrix.Add(new List<double> { -1, -2, -3 });
            matrix.Add(new List<double> { -4, -5, -6 });
            matrix.Add(new List<double> { -7, -8, -9 });

            Assert.AreEqual(Matrix3D.Determinant(matrix), 0);
        }

        [TestMethod]
        public void DeterminantMustBeZero()
        {
            List<List<double>> matrix = new List<List<double>>();
            matrix.Add(new List<double> { 1, 2, 3 });
            matrix.Add(new List<double> { 4, 5, 6 });
            matrix.Add(new List<double> { 7, 8, 9 });

            Assert.AreEqual(Matrix3D.Determinant(matrix), 0);
        }
    }
}
