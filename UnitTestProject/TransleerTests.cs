using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using lin_eindopdracht;

namespace UnitTestProject
{
    [TestClass]
    public class TransleerTests
    {
        [TestMethod]
        public void TransleerPositiveNumbers()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { 1, 2, 3 });
            matrixLijst1.Add(new List<double> { 4, 5, 6 });
            matrixLijst1.Add(new List<double> { 7, 8, 9 });

            Matrix3D matrix = new Matrix3D(matrixLijst1);
            matrix.transleer(2, 3, 4);

            List<List<double>> uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { 3, 4, 5 });
            uitkomst.Add(new List<double> { 7, 8, 9 });
            uitkomst.Add(new List<double> { 11, 12, 13 });

            Assert.AreEqual(TestMethodes.MatrixAreEquel(matrix.matrix, uitkomst), true);
        }

        [TestMethod]
        public void TransleerNegativeNumbers()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { 1, 2, 3 });
            matrixLijst1.Add(new List<double> { 4, 5, 6 });
            matrixLijst1.Add(new List<double> { 7, 8, 9 });

            Matrix3D matrix = new Matrix3D(matrixLijst1);
            matrix.transleer(-2, -3, -4);

            List<List<double>> uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { -1, 0, 1 });
            uitkomst.Add(new List<double> { 1, 2, 3 });
            uitkomst.Add(new List<double> { 3, 4, 5 });

            Assert.AreEqual(TestMethodes.MatrixAreEquel(matrix.matrix, uitkomst), true);
        }

        [TestMethod]
        public void TransleerZeroNumbers()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { 1, 2, 3 });
            matrixLijst1.Add(new List<double> { 4, 5, 6 });
            matrixLijst1.Add(new List<double> { 7, 8, 9 });

            Matrix3D matrix = new Matrix3D(matrixLijst1);
            matrix.transleer(0, 0, 0);

            List<List<double>> uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { 1, 2, 3 });
            uitkomst.Add(new List<double> { 4, 5, 6 });
            uitkomst.Add(new List<double> { 7, 8, 9 });

            Assert.AreEqual(TestMethodes.MatrixAreEquel(matrix.matrix, uitkomst), true);
        }
    }
}
