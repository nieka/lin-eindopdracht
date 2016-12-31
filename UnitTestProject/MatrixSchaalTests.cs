using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lin_eindopdracht;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class MatrixSchaalTests
    {
        [TestMethod]
        public void SchaalPositiveNumbers()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { 1, 2, 3 });
            matrixLijst1.Add(new List<double> { 4, 5, 6 });
            matrixLijst1.Add(new List<double> { 7, 8, 9 });

            Matrix3D matrix = new Matrix3D(matrixLijst1);
            matrix.schaal(2, 3, 4);

            List<List<double>> uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { 2, 4, 6 });
            uitkomst.Add(new List<double> { 12, 15, 18 });
            uitkomst.Add(new List<double> { 28, 32, 36 });

            Assert.AreEqual(TestMethodes.MatrixAreEquel(matrix.matrix, uitkomst), true);
        }
        [TestMethod]
        public void SchaalNegativeNumbers()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { 1, 2, 3 });
            matrixLijst1.Add(new List<double> { 4, 5, 6 });
            matrixLijst1.Add(new List<double> { 7, 8, 9 });

            Matrix3D matrix = new Matrix3D(matrixLijst1);
            matrix.schaal(-2, -3, -4);

            List<List<double>> uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { -2, -4, -6 });
            uitkomst.Add(new List<double> { -12, -15, -18 });
            uitkomst.Add(new List<double> { -28, -32, -36 });

            Assert.AreEqual(TestMethodes.MatrixAreEquel(matrix.matrix, uitkomst), true);
        }

        [TestMethod]
        public void SchaalZeroNumbers()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { 1, 2, 3 });
            matrixLijst1.Add(new List<double> { 4, 5, 6 });
            matrixLijst1.Add(new List<double> { 7, 8, 9 });

            Matrix3D matrix = new Matrix3D(matrixLijst1);
            matrix.schaal(0, 0, 0);

            List<List<double>> uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { 0, 0, 0 });
            uitkomst.Add(new List<double> { 0, 0, 0 });
            uitkomst.Add(new List<double> { 0, 0, 0 });

            Assert.AreEqual(TestMethodes.MatrixAreEquel(matrix.matrix, uitkomst), true);
        }
    }
}
