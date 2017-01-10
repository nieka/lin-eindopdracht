using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using lin_eindopdracht;

namespace UnitTestProject
{
    [TestClass]
    public class RotatieTest
    {
        [TestMethod]
        public void RotatonOnXAS()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { 1, 2 });
            matrixLijst1.Add(new List<double> { 4, 5 });
            matrixLijst1.Add(new List<double> { 7, 8 });

            Matrix3D matrix = new Matrix3D(matrixLijst1);
          //  matrix.rotated(90, RotateType.XAS);

            List<List<double>> uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { 1, 2 });
            uitkomst.Add(new List<double> { -7, -8 });
            uitkomst.Add(new List<double> { 4,5 });

            Assert.AreEqual(TestMethodes.MatrixAreEquel(matrix.matrix, uitkomst), true);
        }

        [TestMethod]
        public void RotatonOnYAS()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { 1, 2 });
            matrixLijst1.Add(new List<double> { 4, 5 });
            matrixLijst1.Add(new List<double> { 7, 8 });

            Matrix3D matrix = new Matrix3D(matrixLijst1);
          //  matrix.rotated(90, RotateType.YAS);

            List<List<double>> uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { -7, -8 });
            uitkomst.Add(new List<double> { 4, 5 });
            uitkomst.Add(new List<double> { 1, 2 });

            Assert.AreEqual(TestMethodes.MatrixAreEquel(matrix.matrix, uitkomst), true);
        }
        [TestMethod]
        public void RotatonOnZAS()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { 1, 2 });
            matrixLijst1.Add(new List<double> { 4, 5 });
            matrixLijst1.Add(new List<double> { 7, 8 });

            Matrix3D matrix = new Matrix3D(matrixLijst1);
           // matrix.rotated(90, RotateType.ZAS);

            List<List<double>> uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { -4, -5 });
            uitkomst.Add(new List<double> { 1, 2 });
            uitkomst.Add(new List<double> { 7, 8 });

            Assert.AreEqual(TestMethodes.MatrixAreEquel(matrix.matrix, uitkomst), true);
        }
    }
}
