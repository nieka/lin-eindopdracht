using lin_eindopdracht;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class DotProductTets
    {
        [TestMethod]
        public void DotProductTestPositiveNumbers()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { 1, 2, 3});
            matrixLijst1.Add(new List<double> { 4, 5, 6 });
            matrixLijst1.Add(new List<double> { 7, 8, 9 });
            List<List<double>> matrixLijst2 = new List<List<double>>();
            matrixLijst2.Add(new List<double> { 2, 0, 0 });
            matrixLijst2.Add(new List<double> { 0, 3, 0 });
            matrixLijst2.Add(new List<double> { 0, 0, 4 });

            List<List<double>>  uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { 2, 6,  12 });
            uitkomst.Add(new List<double> { 8, 15, 24 });
            uitkomst.Add(new List<double> { 14, 24, 36 });
            
            Assert.AreEqual(TestMethodes.MatrixAreEquel(Matrix3D.vermenigvuldig(matrixLijst1, matrixLijst2), uitkomst), true);
        }

        [TestMethod]
        public void DotProductTestNegativeNumber()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { -1, -2, -3 });
            matrixLijst1.Add(new List<double> { -4, -5, -6 });
            matrixLijst1.Add(new List<double> { -7, -8, -9 });
            List<List<double>> matrixLijst2 = new List<List<double>>();
            matrixLijst2.Add(new List<double> { -1, -2, -3 });
            matrixLijst2.Add(new List<double> { -4, -5, -6 });
            matrixLijst2.Add(new List<double> { -7, -8, -9 });

            List<List<double>> uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { 30, 36, 42 });
            uitkomst.Add(new List<double> { 66, 81, 96 });
            uitkomst.Add(new List<double> { 102, 126, 150 });

            Assert.AreEqual(TestMethodes.MatrixAreEquel(Matrix3D.vermenigvuldig(matrixLijst1, matrixLijst2), uitkomst), true);
        }

        [TestMethod]
        public void DotProductEmptyListsTest()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            List<List<double>> matrixLijst2 = new List<List<double>>();

            List<List<double>> uitkomst = new List<List<double>>();

            Assert.AreEqual(TestMethodes.MatrixAreEquel(Matrix3D.vermenigvuldig(matrixLijst1, matrixLijst2), uitkomst), true);
        }

        [TestMethod]
        public void DotProductTestNotEquelMatrixes()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { -1, -2 });
            matrixLijst1.Add(new List<double> { -4, -5 });
            matrixLijst1.Add(new List<double> { -7, -8 });

            List<List<double>> matrixLijst2 = new List<List<double>>();
            matrixLijst2.Add(new List<double> { -1, -2, -3 });
            matrixLijst2.Add(new List<double> { -4, -5, -6 });
            matrixLijst2.Add(new List<double> { -7, -8, -9 });

            List<List<double>> uitkomst = new List<List<double>>();

            Assert.AreEqual(TestMethodes.MatrixAreEquel(Matrix3D.vermenigvuldig(matrixLijst1, matrixLijst2), uitkomst), true);
        }

    }
}
